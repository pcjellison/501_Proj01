using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jellison_Payton
{
    class Deck
    {
        private Card [] deck = new Card [52];            //private field - deck
        private int topCardIndex;   //index of the top card in the deck

        /// <summary>
        /// Creates a deck of 52 cards
        /// </summary>
        Deck()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    Card card = new Jellison_Payton.Card(i, j);
                    deck[count] = card;
                    count++;
                }
            }
            topCardIndex = 51;
        }

        /// <summary>
        /// Uses Knuth's Shuffle to shuffle deck of cards
        /// https://rosettacode.org/wiki/Knuth_shuffle#C.23
        /// Above link was used to create shuffle method
        /// </summary>
        void Shuffle()
        {
            Random rand = new Random();
            for (int i = topCardIndex; i>0; i--)
            {
                int tempNum = rand.Next(1, deck.Length);
                Card tempCard = deck[i];
                deck[i] = deck[tempNum];
                deck[tempNum] = tempCard;
            }
        }

        //return the top card in the deck
        Card Draw (string s)
        {
#if DEBUG
//Draw (string prompt) for debug mode (communicate w/ the customer to determine a card to draw)
//The drawn card must be removed from the deck
//Since this is the debug mode, Draw() can directly call WriteLine() and ReadLine()
//Note that in the release mode, ReadLIne and WriteLine can be called only in BlackJAck (boundary obj)
            for(int i=topCardIndex; i<0; i--)
            {
                if(deck[i].ToString() == s)
                {
                    Card temp = deck[topCardIndex];
                    Card card = deck[i];
                    deck[i] = temp;
                    topCardIndex--;
                    return card;
                }
            }
            Console.WriteLine("Card not available");
            return null;
#else
            //eDraw (string prompt) for release mode (return the card at top of deck)
            //"prompt" is not used (this may be a "not so good" choice
            return deck[topCardIndex];
#endif
        }

        public void ReturnCard(Card c)
        {

        }
    }
}
