using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jellison_Payton
{
    public class BJPlayer
    {
        //-----FIELDS-----------
        protected Card[] hand;
        Deck deck;
        private int topCardHand;   //HOW TO ACCESS PRIVATE FIELD FROM A DIFFERENT CLASS
        public int HandValue;
        public decimal Money;
        protected StringBuilder handString;
        int numAces;        //num of ace cards in hand (used when HandValue > 21)

        public BJPlayer(decimal d, Deck tempDeck)
        {
            Money = d;
            deck = tempDeck;
            hand = new Card[9]; //max hand size is 8
            topCardHand = 0;
            HandValue = 0;
            numAces = 0;
            handString = new StringBuilder();
        }

        public void Draw(string s, bool faceUP)
        {
            //to draw one card from deck and put it in hand
            //updates HandValue, handString, and numAces
            //the "string" argument is a prompt used in drawing a card from deck in the debug mode

            Card c = deck.Draw(s);
            hand[topCardHand] = c;
            handString.Append(c.ToString() + " ");

            if(c.rank > 10)
            {
                HandValue += 10;
            }
            else if(c.rank == 1)
            {
                HandValue += c.rank;
                numAces++;
            }
            else
            {
                HandValue += c.rank;
            }

            topCardHand++;

        }

        public void ReturnHandCardsToDeck()
        {
            //return cards in hand to deck
            for(int i=topCardHand; i>0; i--)
            {
                deck.ReturnCard(hand[topCardHand]);
                hand[topCardHand] = null;
                topCardHand--;
            }
            handString.Clear();
            HandValue = 0;
            numAces = 0;
        }

        public override string ToString()
        {
            return handString.ToString();
        }
    }
}
