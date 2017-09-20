using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jellison_Payton
{
    public class BJCustomer : BJPlayer   //inherits BJPlayer
    {
        //------FIELDS---------
        int NumWins;
        int NumLosses;
        int NumTies;

        public BJCustomer(decimal d, Deck deck) : base(d, deck)
        {
            //pass the arguments to "base"
        }
    }
}
