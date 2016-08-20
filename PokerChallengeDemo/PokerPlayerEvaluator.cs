using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
    class PokerPlayerEvaluator : PokerPlayer
    {
        public PokerPlayerEvaluator(string name = "")
            : base(name)
        {
        }

        public void Copy(PokerPlayer player)
        {
            this.Name = player.Name;
            this.CardsOnHand = player.CardsOnHand;
        }

        protected internal Boolean IsFlush = false;
        protected internal Boolean IsPair = false;
        protected internal Boolean IsThreeOfAKind = false;
        protected internal int Score = 0;
        protected internal SuitType Suit = SuitType.None;
        protected internal RankType Rank = RankType.None;

    }
}
