// Author: Kristian Curcic
// SID: 14103017
// CMP5216 Advanced Software Development UG2 2015/16 Assignment 1
// Exercise 2 - Poker Hand Generator
// Card deck class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2_Poker_Hand_Generator
{
    class CardDeck : PlayingCard
    {
        // All cards in deck
        const int AllCards = 52; 
        // Array of all cards
        private PlayingCard[] deck;

        public CardDeck()
        {
            deck = new PlayingCard[AllCards];
        }

        // Get current deck
        public PlayingCard[] GetDeck { get { return deck; } } 

        // Create deck of cards
        public void CreateDeck()
        {
            int i = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Number n in Enum.GetValues(typeof(Number)))
                {
                    deck[i] = new PlayingCard { CardSuit = s, CardNo = n };
                    i++;
                }
            }

            Shuffle();
        }

        // Shuffle the cards
        public void Shuffle()
        {
            Random rand = new Random();
            PlayingCard temp;

            // Shuffles 20 times
            for (int shuffle = 0; shuffle < 20; shuffle++)
            {
                for (int i = 0; i < AllCards; i++)
                {
                    // Randomy swap cards, loop 52 times
                    int secondCardIndex = rand.Next(13);
                    temp = deck[i];
                    deck[i] = deck[secondCardIndex];
                    deck[secondCardIndex] = temp;
                }
            }
        }
    }
}

