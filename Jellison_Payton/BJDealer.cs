﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jellison_Payton
{
    public class BJDealer : BJPlayer //inherits BJPlayer
    {
        public BJDealer(decimal d, Deck deck) : base(d, deck)
        {
            //pass the arguments to "base"
        }

        public void flipCard(int indexInHand)
        {
            hand[indexInHand].FaceUp = true;
            string cardFlipped = base.hand[indexInHand].ToString();
            base.handString[indexInHand * 3] = cardFlipped[0];
            base.handString[(indexInHand * 3) + 1] = cardFlipped[1];

        }
    }
}
