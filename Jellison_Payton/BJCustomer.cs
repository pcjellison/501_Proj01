using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jellison_Payton
{
    class BJCustomer : BJPlayer   //inherits BJPlayer
    {
        //------FIELDS---------
        int NumWins;
        int NumLosses;
        int NumTies;

        BJCustomer(decimal d, Deck deck) : base(d, deck)
        {
            //pass the arguments to "base"
        }
    }
}
