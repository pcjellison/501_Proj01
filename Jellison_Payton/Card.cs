﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jellison_Payton
{
    class Card
    {
        public enum CardSuit
        {
            Clubs, Spades, Hearts, Diamonds
        }
        public CardSuit Suit { get; private set; }

    }
}
