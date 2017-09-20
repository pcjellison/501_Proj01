using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jellison_Payton
{
    public class BlackJack
    {
        Deck deck;      //reference to the Deck object (to be passed to BJDealer() and BJCustomer() )
        BJDealer dealer;
        BJCustomer customer;
        decimal betAmount;

        BlackJack()
        {
            deck = new Deck();
            dealer = new BJDealer(betAmount, deck);
            customer = new BJCustomer(betAmount, deck);
        }

        void go()
        {
            bool bankrupt = true;
            while(bankrupt == true)
            {
                oneGame();

                customer.ReturnHandCardsToDeck();
                dealer.ReturnHandCardsToDeck();

                displayStat(out bankrupt);

                if(bankrupt == true)
                {
                    break;
                }

                if(checkMoreGame() == false)
                {
                    break;
                }
            }
        }

        void displayStat (out bool bust)
        {
            bust = false;
        }
        
        private void oneGame()
        {
            bool bust;
            Console.WriteLine("========== New Game ==========");
            Console.WriteLine("You have: $" + customer.Money);

            getUsersBet();
            deck.Shuffle();
            dealCards();

            bool nat21 = testNatural21();
            if(nat21 == true)
            {

            }

            bool surrender = testSurrender();
            if(surrender == true)
            {

            }

            
        }

        private bool checkMoreGame()
        {
            while(true)
            {
                Console.Write("More Game (Y or N)?: ");
                string ans = Console.ReadLine();
                char ch;
                
                if(ans.Length > 0)
                {
                    ch = ans[0];
                    if((ch == 'Y') || (ch == 'y'))
                    {
                        return true;
                    }
                    else if((ch == 'N') || (ch == 'n'))
                    {
                        return false;
                    }
                    else
                    {
                        Console.Write("Answer not acceptable");
                    }
                }   //end outer if statement
            }   //end while loop
        }   //end checkMoreGame

        void getUsersBet()
        {
            Console.WriteLine("How much would you like to bet?: ");
            string ans = Console.ReadLine();
            betAmount = Convert.ToInt32(ans);
        }

        void dealCards()
        {

        }

        bool testNatural21()
        {
            return false;
        }

        bool testSurrender()
        {
            return false;
        }
    }
}
