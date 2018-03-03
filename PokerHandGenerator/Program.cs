// Author: Kristian Curcic
// SID: 14103017
// CMP5216 Advanced Software Development UG2 2015/16 Assignment 1
// Exercise 2 - Poker Hand Generator
// Main program


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2_Poker_Hand_Generator
{
    class PokerHandTest
    {
        // Main
        static void Main(string[] args)
        {
            PokerHandTest Program = new PokerHandTest();
            Program.Run();
            Pause("\n\nPress any key to quit.");
        }

        // To exit program
        static void Pause(string s)
        {
            Console.Write(s);
            Console.Read();
        }
        public void Run()
        {
            // Short explanation of program
            Console.WriteLine("Exercise 2 - Poker Hand Generator");
            Console.WriteLine("Developed by Kristian Curcic");
            Console.WriteLine("\nThis program randomly generates a poker hand to three players.");
            Console.WriteLine("It should also be able to determine which player, if any, got a combination,");
            Console.WriteLine("as well as determine the winner.");

            // Prompts user to press key to generate hands
            Console.WriteLine("\n\nPress any key to generate the hands...");
            Console.ReadKey();

            DealOut deal = new DealOut();
            deal.Deal();
            
            Console.ReadKey();

        }
    }
}
