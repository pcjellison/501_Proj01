﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jellison_Payton
{
    public class Deck
    {
        Card [] deck = new Card [52];            //private field - deck
        
        public int topCardIndex;   //index of the top card in the deck

        /// <summary>
        /// Creates a deck of 52 cards
        /// </summary>
        public Deck()
        {
            topCardIndex = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    Card card = new Jellison_Payton.Card(i, j);
                    deck[topCardIndex] = card;
                    topCardIndex++;
                }
            }
            topCardIndex = 51;
            
        }

        /// <summary>
        /// Uses Knuth's Shuffle to shuffle deck of cards
        /// https://rosettacode.org/wiki/Knuth_shuffle#C.23
        /// Above link was used to create shuffle method
        /// </summary>
        public void Shuffle()
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
        public Card Draw (string s)
        {
#if DEBUG
            //Draw (string prompt) for debug mode (communicate w/ the customer to determine a card to draw)
            //The drawn card must be removed from the deck
            //Since this is the debug mode, Draw() can directly call WriteLine() and ReadLine()
            //Note that in the release mode, ReadLIne and WriteLine can be called only in BlackJAck (boundary obj)
            if (s == "XX" || s == "xx")
            {
                Card tempCard = deck[topCardIndex];
                deck[topCardIndex] = null;
                topCardIndex--;
                return tempCard;
            }
            for (int i=topCardIndex; i>0; i--)
            {
                if(deck[i].ToString() == s)
                {
                    Card temp = deck[topCardIndex];
                    Card card = deck[i];
                    deck[i] = temp;
                    deck[topCardIndex] = null;
                    topCardIndex--;
                    return card;
                }
            }
            Console.WriteLine("Card not available");
            return null;
#else
            //eDraw (string prompt) for release mode (return the card at top of deck)
            //"prompt" is not used (this may be a "not so good" choice
                Card tempCard = deck[topCardIndex];
                deck[topCardIndex] = null;
                topCardIndex--;
                return tempCard;
#endif
        }

        /// <summary>
        /// Returns Card back to deck
        /// </summary>
        /// <param name="c">card to be returned</param>
        public void ReturnCard(Card c)
        {
            topCardIndex++;
            deck[topCardIndex] = c;
        }
    }
}
