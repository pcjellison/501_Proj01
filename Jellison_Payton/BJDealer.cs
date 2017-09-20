using System;
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

        void flipCard(int indexInHand)
        {
            //updates handString
            //StringBuilder implements "indexer"; you can set/get/ i_th character
            //using "handString[i]"
            
        }
    }
}
