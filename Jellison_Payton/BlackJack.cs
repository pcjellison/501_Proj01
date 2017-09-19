using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jellison_Payton
{
    class BlackJack
    {
        Deck deck;      //reference to the Deck object (to be passed to BJDealer() and BJCustomer() )
        BJDealer dealer;
        BJCustomer customer;
        decimal betAmount;

        BlackJack()
        {

        }

        void go()
        {
            bool bankrupt = true;
            while(bankrupt == true)
            {
                oneGame();

                customer.ReturnHandToDeck();
                dealer.ReturnHandToDeck();

                displayStat(out bankrupt);
                //displayStat() sets "bankrupt" to true if either player bankrupts

                if(bankrupt == true)
                {
                    break;
                }

                if(checkMoreGames() == false)
                {
                    break;
                }
                //chekcMoreGame() return true if the customer wants another game
                //false otherwise
            }
        }

        private void oneGame()
        {
            bool bust;
            Console.WriteLine("========== New Game ==========");
            Console.WriteLine("You have: $" + customer.Money);
        }
    }
}
