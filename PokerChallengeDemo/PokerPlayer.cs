using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGame
{
     abstract class Player {
         protected internal abstract void Receive(PlayingCard card);
    }

     class PokerPlayer : Player
    {
        internal List<PlayingCard> CardsOnHand = new List<PlayingCard>();
        public string Name { get; set; }

        public PokerPlayer(string name)
        {
            this.Name = name;
        }

        protected internal override void Receive(PlayingCard card)
        {
            CardsOnHand.Add(card);
        }

    }
}
