using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerChallengeRef
{
    public class PokerHand : PokerPlayer
    {
        public Boolean IsFlush = false;
        public Boolean IsPair = false;
        public Boolean IsThreeOfAKind = false;
        public SuitType DominantSuit = SuitType.None;
        public RankType DominantRank = RankType.None;
        public HandCategory Category;
        public int Score = 0;

        public PokerHand(string name = "")
            : base(name)
        { }

        private void Copy(PokerPlayer player)
        {
            this.Name = player.Name;
            this.CardsOnHand = player.CardsOnHand;
        }
        
        /// <summary>
        /// Arrange/strategize cards in subsets: Flush, Three of a Kind, One Pair, High Card
        /// </summary>
        /// <param name="player"></param>
        public void Arrange(PokerPlayer player)
        {
            this.Copy(player);

            if (CheckIsFlush())
            {
                this.Category = HandCategory.Flush;
            }
            else if (CheckIsThreeOfAKind())
            {
                this.Category = HandCategory.ThreeOfaKind;
            }
            else if (CheckIsPair())
            {
                this.Category = HandCategory.OnePair;
            }
            else { this.Category = HandCategory.HighCard; }

            //Get Score to get High Card
            this.Score = this.CardsOnHand.AsEnumerable().Sum(r => (int)r.Rank);
        }

        /// <summary>
        /// Verify if contains Flush and assign value to Poker Hand
        /// </summary>
        /// <returns></returns>
        private Boolean CheckIsFlush()
        {
            var getFlush = from cards in this.CardsOnHand
                                 group cards by cards.Suit into cards
                                 orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode())
                                 select new { Suit = cards.Key, Count = cards.Count() };

            if (getFlush.Count() == 1)
            {
                var _suit = getFlush.DefaultIfEmpty().First().Suit;

                this.DominantSuit = (SuitType)_suit;
                this.IsFlush = true;

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verify if contains Three of A Kind and assign value to Poker Hand
        /// </summary>
        /// <returns></returns>
        private Boolean CheckIsThreeOfAKind()
        {            
            var getThreeOfAKind = from cards in this.CardsOnHand
                                        group cards by cards.Rank into cards
                                        where cards.Count() == 3
                                        orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode()) 
                                        select new { Rank = cards.Key, Count = cards.Count() };

            if (getThreeOfAKind.Count() >= 1)
            {
                var _rank = getThreeOfAKind.DefaultIfEmpty().First().Rank;

                this.DominantRank = (RankType)_rank;
                this.IsThreeOfAKind = true;

                return true;
            }
            else
            {
                return false;
            }
         
        }
        
            /// <summary>
        /// Verify if contains Pair and assign value to Poker Hand
        /// </summary>
        /// <returns></returns>
        private Boolean CheckIsPair()
        {
            //Sort first by Suit to consider in ranking
            var cardsSortedBySuit = this.CardsOnHand.AsEnumerable().OrderBy(s => s.Suit);
            
            var getPair = from cards in cardsSortedBySuit
                          group cards by cards.Rank into cards
                          where cards.Count() == 2
                          orderby Convert.ChangeType(cards.Key, cards.Key.GetTypeCode())
                          select new { Rank = cards.Key, Count = cards.Count() };

            if (getPair.Count() >= 1)
            {
                var _rank = getPair.DefaultIfEmpty().First().Rank;

                this.IsPair = true;
                this.DominantRank = (RankType)_rank;

                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
