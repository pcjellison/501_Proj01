using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jellison_Payton
{
    class Deck
    {
        private int topCardIndex;   //index of the top card in the deck

        Deck()
        {

        }
        
        void Shuffle()
        {

        }

        //return the top card in the deck
        Card Draw (string s)
        {
#if DEBUG
//Draw (string prompt) for debug mode (communicate w/ the customer to determine a card to draw)
//The drawn card must be removed from the deck
//Since this is the debug mode, Draw() can directly call WriteLine() and ReadLine()
//Note that in the release mode, ReadLIne and WriteLine can be called only in BlackJAck (boundary obj)
#else
            //eDraw (string prompt) for release mode (return the card at top of deck)
            //"prompt" is not used (this may be a "not so good" choice
#endif
        }

        void ReturnCard(Card)
        {

        }
    }
}
