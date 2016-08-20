using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PokerChallengeRef
{
    public abstract class PokerGame
    {
        public abstract void GivePlayingCards(PokerPlayer player, PlayingCard card);
        public abstract void AddPlayer(PokerPlayer player);
        public abstract void Evaluate();
        public abstract PokerHand GetWinner();
    }

    public class PlayPokerGame : PokerGame
    {
        private Dictionary<string, PokerPlayer> ListOfPokerPlayers = new Dictionary<string, PokerPlayer>();
        private PokerHand Winner { get; set; }

        public override void GivePlayingCards(PokerPlayer player, PlayingCard card)
        {
            player.ReceivePlayingCard(card);
        }

        public override void AddPlayer(PokerPlayer player)
        {
            if (ListOfPokerPlayers.ContainsKey(player.Name)) { throw new Exception("Player name already exists"); }

            ListOfPokerPlayers.Add(player.Name, player);
        }

        public override PokerHand GetWinner()
        {
            this.CheckHasDuplicates();
            this.Evaluate();

            PokerHand _winner = this.Winner;

            return _winner;
        }

        public override void Evaluate()
        {
            List<PokerHand> _pokerHands = new List<PokerHand>();

            foreach (KeyValuePair<string, PokerPlayer> pair in ListOfPokerPlayers)
            {
                PokerHand _pokerHand = new PokerHand();
                _pokerHand = ListOfPokerPlayers[pair.Key].GetPokerHand();

                _pokerHands.Add(_pokerHand);
            }

            var sortPokerHandScore = from foobars in _pokerHands
                                     orderby foobars.IsFlush descending, foobars.IsThreeOfAKind descending, foobars.IsPair descending, foobars.Score descending, Convert.ChangeType(foobars.DominantSuit, foobars.DominantSuit.GetTypeCode()) ascending
                                     select foobars;

            Winner = sortPokerHandScore.DefaultIfEmpty().First();

        }

        private void CheckHasDuplicates()
        {
            ArrayList _playingCards = new ArrayList();

            foreach (KeyValuePair<string, PokerPlayer> pair in ListOfPokerPlayers)
            {
                foreach (PlayingCard card in ListOfPokerPlayers[pair.Key].CardsOnHand)
                {
                    string _card = string.Concat(card.Rank, card.Suit);

                    if (_playingCards.Contains(_card))
                    {
                        throw new Exception("Duplicate card(s) found");
                    }
                    else { _playingCards.Add(_card); }
                }
            }

        }

    }

}
