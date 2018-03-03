// Author: Kristian Curcic
// SID: 14103017
// CMP5216 Advanced Software Development UG2 2015/16 Assignment 1
// Exercise 2 - Poker Hand Generator
// Playing card class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2_Poker_Hand_Generator
{
    class PlayingCard
    {
        public enum Suit
        {
            Hearts, Clubs, Diamonds, Spades
        }

        public enum Number
        {
            Two = 2, Three, Four, Five, Six, Seven, Eight,
            Nine, Ten, Jack, Queen, King, Ace
        }

        public Suit CardSuit { get; set; }
        public Number CardNo { get; set; }
    }
}

