﻿using System;
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
        private int topCardIndex;   //HOW TO ACCESS PRIVATE FIELD FROM A DIFFERENT CLASS
        int HandValue;
        decimal Money;
        protected StringBuilder handString = new StringBuilder();
        int numAces;        //num of ace cards in hand (used when HandValue > 21)

        public BJPlayer(decimal d, Deck deck)
        {
            Money = d;
        }

        void Draw(string s, bool faceUP)
        {
            //to draw one card from deck and put it in hand
            //updates HandValue, handString, and numAces
            //the "string" argument is a promp used in drawing a card from deck in the debug mode

            
        }

        void ReturnHandCardsToDeck()
        {
            //return cards in hand to deck
            foreach(Card c in hand)
            {
                deck.ReturnCard(c);
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
