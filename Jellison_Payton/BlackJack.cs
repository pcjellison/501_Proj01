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

        public BlackJack()
        {
            deck = new Deck();
            dealer = new BJDealer(betAmount, deck);
            customer = new BJCustomer(betAmount, deck);
        }

        public void go()
        {
            customer.Money = 100;
            dealer.Money = 200;
            bool bankrupt = false;
            while (bankrupt == false)
            {
                oneGame();

                customer.ReturnHandCardsToDeck();
                dealer.ReturnHandCardsToDeck();

                bankrupt = checkBankrupt();

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

        bool checkBankrupt()
        {
            if(customer.Money < 1)
            {
                Console.WriteLine("You are out of money.");
                return true;
            }
            else if (dealer.Money < 1)
            {
                Console.WriteLine("Dealer is out of  money.");
                return true;
            }
            return false;
        }

        private void oneGame()
        {
            customer.ReturnHandCardsToDeck();
            dealer.ReturnHandCardsToDeck();

            Console.WriteLine("========== New Game ==========");
            Console.WriteLine("You have: $" + customer.Money);

            getUsersBet();
            deck.Shuffle();
            dealCards();

            testNat21();
            bool surr = false;
            surr = testSurrender();
            if(surr == true)
            {
                decimal temp = betAmount;
                betAmount = (temp / (decimal)2.0);

                Console.WriteLine("Dealer won and got $" + betAmount + " from User");
                customer.NumLosses++;
                Console.WriteLine("You Won: " + customer.NumWins + ", Lost: " + customer.NumLosses + ", and Tied: " + customer.NumTies + " times.");
                customer.Money -= betAmount;
                dealer.Money += betAmount;

                if(checkMoreGame() == false)
                {
                    Console.WriteLine("Thank you for playing");
                    Environment.Exit(0);
                }
                else
                {
                    oneGame();
                }
            }
            
            customerTurn();
            testNat21();
            dealerTurn();
            testHandValue();
            
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

            Console.WriteLine("You bet $" + betAmount);
        }

        void dealCards()
        {
            bool faceUp = true;
            string cardToDraw = null;
#if DEBUG
            Console.WriteLine("Input 1st card for customer <3H, AD, TC, etc. or XX to draw from deck>: ");
            cardToDraw = Console.ReadLine();
            customer.Draw(cardToDraw, faceUp);

            Console.WriteLine("Input 1st card for dealer<3H, AD, TC, etc. or XX to draw from deck>: ");
            cardToDraw = Console.ReadLine();
            dealer.Draw(cardToDraw, faceUp);

            Console.WriteLine("Input 2nd card for customer <3H, AD, TC, etc. or XX to draw from deck>: ");
            cardToDraw = Console.ReadLine();
            customer.Draw(cardToDraw, faceUp);

            Console.WriteLine("Input 2nd card for dealer <3H, AD, TC, etc. or XX to draw from deck>: ");
            cardToDraw = Console.ReadLine();
            faceUp = false;
            dealer.Draw(cardToDraw, faceUp);

            Console.WriteLine("Your hand: " + customer.ToString() + ", Hand Value: " + customer.HandValue);
            Console.WriteLine("Dealer's hand: " + dealer.ToString() + ", Hand Value: " + dealer.HandValue);
# else
            customer.Draw(cardToDraw, faceUp);
            customer.Draw(cardToDraw, faceUp);
            dealer.Draw(cardToDraw, faceUp);
            dealer.Draw(cardToDraw, faceUp);

            Console.WriteLine("Your hand: " + customer.ToString() + ", Hand Value: " + customer.HandValue);
            Console.WriteLine("Dealer's hand: " + dealer.ToString() + ", Hand Value: " + dealer.HandValue);
#endif
        }

        void testNat21()
        {
            if (customer.HandValue == 21 && dealer.HandValue == 21)
            {
                standoff();
            }
            else if (customer.HandValue == 21 && dealer.HandValue != 21)
            {
                decimal temp = betAmount;
                betAmount = (temp * (decimal)2.5);
                customerWins();
            }
        }
        void testHandValue()
        {
            //if player gets nat21 he gets 2.5x bet
            //else if both get nat21 - standoff

            if (customer.HandValue > 21)
            {
                customerBusts();
                if (checkMoreGame() == false)
                {
                    Console.WriteLine("Thank you for playing");
                    Environment.Exit(0);
                }
                else
                {
                    oneGame();
                }
            }
            else if (dealer.HandValue > 21)
            {
                dealerBusts();
                if (checkMoreGame() == false)
                {
                    Console.WriteLine("Thank you for playing");
                    Environment.Exit(0);
                }
                else
                {
                    oneGame();
                }
            }
            else if(customer.HandValue > dealer.HandValue)
            {
                customerWins();
                if (checkMoreGame() == false)
                {
                    Console.WriteLine("Thank you for playing");
                    Environment.Exit(0);
                }
                else
                {
                    oneGame();
                }
            }
            else if (dealer.HandValue > customer.HandValue)
            {
                dealerWins();
                if (checkMoreGame() == false)
                {
                    Console.WriteLine("Thank you for playing");
                    Environment.Exit(0);
                }
                else
                {
                    oneGame();
                }
            }
            else if(customer.HandValue == dealer.HandValue)
            {
                standoff();
                if (checkMoreGame() == false)
                {
                    Console.WriteLine("Thank you for playing");
                    Environment.Exit(0);
                }
                else
                {
                    oneGame();
                }
            }
        }

        bool testSurrender()
        {
            Console.WriteLine("Do you want to surrender <Y or N>?: ");
            string ans = Console.ReadLine();

            if(ans == "Y" || ans == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void customerTurn()
        {
            bool hits = true;
            while (hits == true)
            {
                if(customer.HandValue > 21)
                {
                    customerBusts();
                    break;
                }
                Console.WriteLine("Will you HIT  or STAND <H or S>?: ");
                string ans = Console.ReadLine();
                if(ans == "S" || ans == "s")
                {
                    hits = false;
                    break;
                }
#if DEBUG
                Console.WriteLine("Input card for customer <3H, AD, TC, etc. or XX to draw from deck>: ");
                string cardToDraw = Console.ReadLine();
                bool faceUp = true;
                customer.Draw(cardToDraw, faceUp);
                Console.WriteLine("Your hand: " + customer.ToString() + ", Hand Value: " + customer.HandValue);
#else
                string cardToDraw = null;
                bool faceUp = true;
                customer.Draw(cardToDraw, faceUp);
                Console.WriteLine("Your hand: " + customer.ToString() + ", Hand Value: " + customer.HandValue);
#endif
            }
        }

        void dealerTurn()
        {
            dealer.flipCard(1);
            Console.WriteLine("Now, Dealer's Turn");
            bool hits = true;
            while (hits == true)
            {
                Console.WriteLine("Dealer's hand: " + dealer.ToString() + ", Hand Value: " + dealer.HandValue);
                if(dealer.HandValue >21)
                {
                    dealerBusts();
                    break;
                }
                if(dealer.HandValue > 16)
                {
                    hits = false;
                    break;
                }
#if DEBUG
                Console.WriteLine("Input card for dealer <3H, AD, TC, etc. or XX to draw from deck>: ");
                string cardToDraw = Console.ReadLine();
                bool faceUp = true;
                dealer.Draw(cardToDraw, faceUp);
#else
                string cardToDraw = null;
                bool faceUp = true;
                customer.Draw(cardToDraw, faceUp);
#endif
            }
        }

        void customerWins()
        {
            Console.WriteLine("You won and got $" + betAmount + " from Dealer");
            customer.NumWins++;
            Console.WriteLine("You Won: " + customer.NumWins + ", Lost: " + customer.NumLosses + ", and Tied: " + customer.NumTies + " times.");
            customer.Money += betAmount;
            dealer.Money -= betAmount;
        }

        void dealerWins()
        {
            Console.WriteLine("Dealer won and got $" + betAmount + " from User");
            customer.NumLosses++;
            Console.WriteLine("You Won: " + customer.NumWins + ", Lost: " + customer.NumLosses + ", and Tied: " + customer.NumTies + " times.");
            customer.Money -= betAmount;
            dealer.Money += betAmount;
        }

        void standoff()
        {
            Console.WriteLine("Stand Off");
            customer.NumTies++;
            Console.WriteLine("You Won: " + customer.NumWins + ", Lost: " + customer.NumLosses + ", and Tied: " + customer.NumTies + " times.");
        }

        void customerBusts()
        {
            Console.WriteLine("You Bust");
            customer.NumLosses++;
            Console.WriteLine("Dealer won and got $" + betAmount + " from You");
            Console.WriteLine("You Won: " + customer.NumWins + ", Lost: " + customer.NumLosses + ", and Tied: " + customer.NumTies + " times.");
            customer.Money -= betAmount;
            dealer.Money += betAmount;
        }

        void dealerBusts()
        {
            Console.WriteLine("Dealer Busted");
            customer.NumWins++;
            Console.WriteLine("You won and got $" + betAmount + " from Dealer");
            Console.WriteLine("You Won: " + customer.NumWins + ", Lost: " + customer.NumLosses + ", and Tied: " + customer.NumTies + " times.");
            customer.Money += betAmount;
            dealer.Money -= betAmount;
        }
    }
}
