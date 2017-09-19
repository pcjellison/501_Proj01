using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jellison_Payton
{
    class Card
    {
        int rank;
        internal enum CardSuit { D, H, S, C };
        internal CardSuit suit { get; set; }
        bool FaceUp = true;

        /// <summary>
        /// Card constructor
        /// </summary>
        /// <param name="s">suit</param>
        /// <param name="r">rank</param>
        public Card (int s, int r)
        {
            suit = (Card.CardSuit)s;
            rank = r;
        }

        /// <summary>
        /// Checks if card is face up and if not, it returns the rank and suit of a card
        /// </summary>
        /// <returns>rank and suit of card</returns>
        public override string ToString()
        {
            if(FaceUp == false)
            {
                return "XX";
            }

            if(this.rank == 1)
            {
                return ('A' + this.suit.ToString());
            }
            else if (this.rank == 10)
            {
                return ('T' + this.suit.ToString());
            }
            else if (this.rank == 11)
            {
                return ('J' + this.suit.ToString());
            }
            else if (this.rank == 12)
            {
                return ('Q' + this.suit.ToString());
            }
            else if (this.rank == 13)
            {
                return ('K' + this.suit.ToString());
            }
            else
            {
                return (this.rank.ToString() + this.suit.ToString());
            }
        }
    }
}
