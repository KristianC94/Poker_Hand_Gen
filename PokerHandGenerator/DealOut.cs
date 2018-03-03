// Author: Kristian Curcic
// SID: 14103017
// CMP5216 Advanced Software Development UG2 2015/16 Assignment 1
// Exercise 2 - Poker Hand Generator
// Dealing cards class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2_Poker_Hand_Generator
{
    class DealOut : CardDeck
    {
        private PlayingCard[] Player1;
        private PlayingCard[] Player2;
        private PlayingCard[] Player3;

        private PlayingCard[] Sorted1;
        private PlayingCard[] Sorted2;
        private PlayingCard[] Sorted3;

        public DealOut()
        {
            Player1 = new PlayingCard[5];
            Player2 = new PlayingCard[5];
            Player3 = new PlayingCard[5];

            Sorted1 = new PlayingCard[5];
            Sorted2 = new PlayingCard[5];
            Sorted3 = new PlayingCard[5];

        }

        public void Deal()
        {
            CreateDeck();
            GetHand();
            SortCards();
            DisplayCards();
            Evaluate();
        }

        // Gives 5 cards to each player
        public void GetHand()
        {
            for (int i = 0; i < 5; i++)
                Player1[i] = GetDeck[i];
            for (int i = 5; i < 10; i++)
                Player2[i - 5] = GetDeck[i];
            for (int i = 10; i < 15; i++)
                Player3[i - 10] = GetDeck[i];
        }

        public void SortCards()
        {
            var SeePlayer1 = from hand in Player1
                             orderby hand.CardNo
                             select hand;

            var SeePlayer2 = from hand in Player2
                             orderby hand.CardNo
                             select hand;

            var SeePlayer3 = from hand in Player3
                             orderby hand.CardNo
                             select hand;

            var index = 0;
            foreach (var element in SeePlayer1.ToList())
            {
                Sorted1[index] = element;
                index++;
            }

            index = 0;
            foreach (var element in SeePlayer2.ToList())
            {
                Sorted2[index] = element;
                index++;
            }

            index = 0;
            foreach (var element in SeePlayer3.ToList())
            {
                Sorted3[index] = element;
                index++;
            }
        }



        public void DisplayCards()
        {
            Console.WriteLine("\n\nPlayer 1s cards are:\n");
            foreach (var card in Player1)
            {
                Console.Write(card.CardNo.ToString());
                Console.Write(" of ");
                Console.Write(card.CardSuit.ToString());
                Console.Write("\n");
            }

            Console.WriteLine("\n\nPlayer 2s cards are:\n");
            foreach (var card in Player2)
            {
                Console.Write(card.CardNo.ToString());
                Console.Write(" of ");
                Console.Write(card.CardSuit.ToString());
                Console.Write("\n");
            }

            Console.WriteLine("\n\nPlayer 3s cards are:\n");
            foreach (var card in Player3)
            {
                Console.Write(card.CardNo.ToString());
                Console.Write(" of ");
                Console.Write(card.CardSuit.ToString());
                Console.Write("\n");
            }
        }

        public void Evaluate()
        {
            // Initialise envaluations, with sorted hand passing to constructor
            Evaluator Player1Evaluator = new Evaluator(Sorted1);
            Evaluator Player2Evaluator = new Evaluator(Sorted2);
            Evaluator Player3Evaluator = new Evaluator(Sorted3);

            // Get players' hands
            Hand Player1 = Player1Evaluator.EvaluateHand();
            Hand Player2 = Player2Evaluator.EvaluateHand();
            Hand Player3 = Player3Evaluator.EvaluateHand();

            // Display each hand
            Console.WriteLine("\n\nPlayer1s hand: " + Player1);
            Console.WriteLine("\nPlayer2s hand: " + Player2);
            Console.WriteLine("\nPlayer3s hand: " + Player3);

            // Evaluate
            if (Player1 > Player2 && (Player1 > Player3))
            {
                Console.WriteLine("\n\nPlayer1 wins");
            }

            else if (Player1 < Player2 && (Player3 < Player2))
            {
                Console.WriteLine("\n\nPlayer2 wins");
            }

            else if (Player1 < Player3 && (Player2 < Player3))
            {
                Console.WriteLine("\n\nPlayer3 wins");
            }

            // If all have same hand, evaluate hand values
            else
            {
                // Higher poker hand
                if (Player1Evaluator.HandValues.Total > Player2Evaluator.HandValues.Total 
                    && (Player1Evaluator.HandValues.Total > Player3Evaluator.HandValues.Total))
                    Console.WriteLine("\n\nPlayer1 wins");
                else if (Player1Evaluator.HandValues.Total < Player2Evaluator.HandValues.Total
                    && Player3Evaluator.HandValues.Total < Player2Evaluator.HandValues.Total)
                    Console.WriteLine("\n\nPlayer2 wins");
                else if (Player1Evaluator.HandValues.Total < Player3Evaluator.HandValues.Total
                    && Player2Evaluator.HandValues.Total < Player3Evaluator.HandValues.Total)
                    Console.WriteLine("\n\nPlayer3 wins");

                // If all hanve the same poker hand player with next highest wins
                else if (Player1Evaluator.HandValues.HighCard > Player2Evaluator.HandValues.HighCard
                    && Player1Evaluator.HandValues.HighCard > Player3Evaluator.HandValues.HighCard)
                    Console.WriteLine("\n\nPlayer1 wins");
                else if (Player1Evaluator.HandValues.HighCard < Player2Evaluator.HandValues.HighCard
                    && Player3Evaluator.HandValues.HighCard > Player2Evaluator.HandValues.HighCard)
                    Console.WriteLine("\n\nPlayer2 wins");
                else if (Player1Evaluator.HandValues.HighCard < Player3Evaluator.HandValues.HighCard
                    && Player3Evaluator.HandValues.HighCard > Player2Evaluator.HandValues.HighCard)
                    Console.WriteLine("\n\nPlayer3 wins");
                else
                    Console.WriteLine("\n\nEveryone's a winner...");
            }
        }
    }
}


