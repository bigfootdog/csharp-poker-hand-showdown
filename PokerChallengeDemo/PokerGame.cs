using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    abstract class PokerGame
    {
        public abstract void GivePlayingCards(PokerPlayer player, PlayingCard card);
        public abstract void JoinPlayer(string name, PokerPlayer player);
        protected abstract void Evaluate();
        public abstract void GetWinner();
    }

    class PlayPokerGame : PokerGame
    {
        private Dictionary<string, PokerPlayer> ListOfPokerPlayers = new Dictionary<string, PokerPlayer>();
        protected List<PokerPlayerEvaluator> listOfProcessed = new List<PokerPlayerEvaluator>();

        public override void GivePlayingCards(PokerPlayer player, PlayingCard card)
        {
            player.Receive(card);
        }

        public override void JoinPlayer(string name, PokerPlayer player)
        {
            ListOfPokerPlayers.Add(name, player);
        }

        private void GetHighCard(ref PokerPlayerEvaluator player)
        {
            List<PlayingCard> list = player.CardsOnHand;

            var queryGetByGroupHaving = from student in list
                                        select new { Total = list.Sum(x => (int)x.Rank) };

            var _cards = queryGetByGroupHaving.DefaultIfEmpty().First();
            player.Score = _cards.Total;
        }

        private Boolean IsFlush(ref PokerPlayerEvaluator player)
        {
            Boolean result;
            List<PlayingCard> listOfPlayingCards = player.CardsOnHand;

            var queryFindFlush = from cardsOnHand in listOfPlayingCards
                                 group cardsOnHand by cardsOnHand.Suit into cards
                                 orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode())
                                 select new { Suit = cards.Key, Count = cards.Count() };

            if (queryFindFlush.Count() == 1)
            {
                var _suit = queryFindFlush.DefaultIfEmpty().First().Suit;
                player.Suit = (SuitType)_suit;
                player.IsFlush = true;

                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        private Boolean IsPair(ref PokerPlayerEvaluator player)
        {
            Boolean result;
            List<PlayingCard> listOfPlayingCards = player.CardsOnHand;

            var queryFindPair = from cardsOnHand in listOfPlayingCards
                                group cardsOnHand by cardsOnHand.Rank into cards
                                where cards.Count() == 2
                                orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode())
                                select new { Rank = cards.Key, Count = cards.Count() };

            if (queryFindPair.Count() >= 1)
            {
                var _rank = queryFindPair.DefaultIfEmpty().First().Rank;

                player.IsPair = true;
                player.Rank = (RankType)_rank;

                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        private Boolean IsThreeOfAKind(ref PokerPlayerEvaluator player)
        {
            Boolean result;
            List<PlayingCard> listOfPlayingCards = player.CardsOnHand;

            var queryFindThreeOfAKind = from cardsOnHand in listOfPlayingCards
                                        group cardsOnHand by cardsOnHand.Rank into cards
                                        where cards.Count() == 3
                                        orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode())
                                        select new { last = cards.Key, count = cards.Count() };

            if (queryFindThreeOfAKind.Count() >= 1)
            {
                var _rank = queryFindThreeOfAKind.DefaultIfEmpty().First().last;
                RankType d = (RankType)_rank;
                player.IsThreeOfAKind = true;

                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public override void GetWinner()
        {
            this.Evaluate();
            
        }

        protected override void Evaluate()
        {
            foreach (KeyValuePair<string, PokerPlayer> pair in ListOfPokerPlayers)
            {
                string _playerName = pair.Value.Name;

                PokerPlayerEvaluator playerEvaluationResult = new PokerPlayerEvaluator();
                playerEvaluationResult.Copy(pair.Value); // .CardsOnHand = pair.Value.CardsOnHand;

                //ListOfPokerPlayers[_playerName].Name = "d";

                if (IsFlush(ref playerEvaluationResult))
                {
                }
                else if (IsThreeOfAKind(ref playerEvaluationResult))
                {
                }
                else { IsPair(ref playerEvaluationResult); }

                GetHighCard(ref playerEvaluationResult);

                listOfProcessed.Add(playerEvaluationResult);
            }
            
            var resultSet = from foobars in listOfProcessed
                            orderby foobars.IsFlush descending, foobars.IsThreeOfAKind descending, foobars.IsPair descending, foobars.Score descending, Convert.ChangeType(foobars.Suit, foobars.Suit.GetTypeCode()) ascending
                            select foobars;

            foreach (var single in resultSet)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} ", single.Name, single.Suit.ToString(), single.IsFlush, single.IsPair, single.IsThreeOfAKind, single.Score);
            }

        }

    }


}
