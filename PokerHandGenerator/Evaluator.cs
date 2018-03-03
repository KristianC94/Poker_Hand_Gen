// Author: Kristian Curcic
// SID: 14103017
// CMP5216 Advanced Software Development UG2 2015/16 Assignment 1
// Exercise 2 - Poker Hand Generator
// Hand evaluator class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2_Poker_Hand_Generator
{
        public enum Hand
        {
            None, Flush, Straight, StraightFlush, RoyalFlush, Poker,
            ThreeKind, FullHouse, TwoPairs, Pair
        }

        public struct HandValue
        {
            public int Total { get; set; }
            public int HighCard { get; set; }
        }

        class Evaluator : PlayingCard
        {
            private int HeartsSum;
            private int DiamondsSum;
            private int ClubsSum;
            private int SpadesSum;
            private PlayingCard[] cards;
            private HandValue HandValue;

            public Evaluator(PlayingCard[] SortedHand)
            {
                HeartsSum = 0;
                DiamondsSum = 0;
                ClubsSum = 0;
                SpadesSum = 0;
                cards = new PlayingCard[5];
                Cards = SortedHand;
                HandValue = new HandValue();
            }

            public HandValue HandValues
            {
                get { return HandValue; }
                set { HandValue = value; }
            }

            public PlayingCard[] Cards
            {
                get { return cards; }
                set
                {
                    cards[0] = value[0];
                    cards[1] = value[1];
                    cards[2] = value[2];
                    cards[3] = value[3];
                    cards[4] = value[4];
                }
            }

            public Hand EvaluateHand()
            {
                // Number of each suit in hand
                getNumberOfSuit();
                if (Poker())
                    return Hand.Poker;
                else if (FullHouse())
                    return Hand.FullHouse;
                else if (Flush())
                    return Hand.Flush;
                else if (Straight())
                    return Hand.Straight;
                else if (StraightFlush())
                    return Hand.StraightFlush;
                else if (ThreeKind())
                    return Hand.ThreeKind;
                else if (TwoPairs())
                    return Hand.TwoPairs;
                else if (Pair())
                    return Hand.Pair;

                // If there are no combinations, calculate highest card
                HandValue.HighCard = (int)cards[4].CardNo;
                return Hand.None;
            }

            private void getNumberOfSuit()
            {
                foreach (var element in Cards)
                {
                    if (element.CardSuit == PlayingCard.Suit.Hearts)
                        HeartsSum++;
                    else if (element.CardSuit == PlayingCard.Suit.Diamonds)
                        DiamondsSum++;
                    else if (element.CardSuit == PlayingCard.Suit.Clubs)
                        ClubsSum++;
                    else if (element.CardSuit == PlayingCard.Suit.Spades)
                        SpadesSum++;
                }
            }

            private bool Poker()
            {
                // Add first four cards, last card is highest
                if (cards[0].CardNo == cards[1].CardNo && cards[0].CardNo == cards[2].CardNo && cards[0].CardNo == cards[3].CardNo)
                {
                    HandValue.Total = (int)cards[1].CardNo * 4;
                    HandValue.HighCard = (int)cards[4].CardNo;
                    return true;
                }
                else if (cards[1].CardNo == cards[2].CardNo && cards[1].CardNo == cards[3].CardNo && cards[1].CardNo == cards[4].CardNo)
                {
                    HandValue.Total = (int)cards[1].CardNo * 4;
                    HandValue.HighCard = (int)cards[0].CardNo;
                    return true;
                }

                return false;
            }

            private bool FullHouse()
            {
                // First 3 cards and last 2 cards are the same or vice versa
                if ((cards[0].CardNo == cards[1].CardNo && cards[0].CardNo == cards[2].CardNo && cards[3].CardNo == cards[4].CardNo) ||
                    (cards[0].CardNo == cards[1].CardNo && cards[2].CardNo == cards[3].CardNo && cards[2].CardNo == cards[4].CardNo))
                {
                    HandValue.Total = (int)(cards[0].CardNo) + (int)(cards[1].CardNo) + (int)(cards[2].CardNo) +
                        (int)(cards[3].CardNo) + (int)(cards[4].CardNo);
                    return true;
                }

                return false;
            }

            private bool Flush()
            {
                // Five cards of same suit
                if (HeartsSum == 5 || DiamondsSum == 5 || ClubsSum == 5 || SpadesSum == 5)
                {
                    // Player with higher cards wins
                    HandValue.Total = (int)cards[4].CardNo;
                    return true;
                }

                return false;
            }

            private bool Straight()
            {
                // 5 consecutive values
                if (cards[0].CardNo + 1 == cards[1].CardNo &&
                    cards[1].CardNo + 1 == cards[2].CardNo &&
                    cards[2].CardNo + 1 == cards[3].CardNo &&
                    cards[3].CardNo + 1 == cards[4].CardNo)
                {
                    // Player with highest final card wins
                    HandValue.Total = (int)cards[4].CardNo;
                    return true;
                }

                return false;
            }

            // If five consecutive ranked cards in same suit
            private bool StraightFlush()
            {
                if (HeartsSum == 5 || DiamondsSum == 5 || ClubsSum == 5 || SpadesSum == 5
                    && (cards[0].CardNo + 1 == cards[1].CardNo &&
                    cards[1].CardNo + 1 == cards[2].CardNo &&
                    cards[2].CardNo + 1 == cards[3].CardNo &&
                    cards[3].CardNo + 1 == cards[4].CardNo))
                {
                    HandValue.Total = (int)cards[4].CardNo;
                    return true;
                }

                return false;

            }

            private bool ThreeKind()
            {
                // Three cards with same value
                if ((cards[0].CardNo == cards[1].CardNo && cards[0].CardNo == cards[2].CardNo) ||
                (cards[1].CardNo == cards[2].CardNo && cards[1].CardNo == cards[3].CardNo))
                {
                    HandValue.Total = (int)cards[2].CardNo * 3;
                    HandValue.HighCard = (int)cards[4].CardNo;
                    return true;
                }
                else if (cards[2].CardNo == cards[3].CardNo && cards[2].CardNo == cards[4].CardNo)
                {
                    HandValue.Total = (int)cards[2].CardNo * 3;
                    HandValue.HighCard = (int)cards[1].CardNo;
                    return true;
                }
                return false;
            }

            private bool TwoPairs()
            {
                // If hand contains two pairs
                if (cards[0].CardNo == cards[1].CardNo && cards[2].CardNo == cards[3].CardNo)
                {
                    HandValue.Total = ((int)cards[1].CardNo * 2) + ((int)cards[3].CardNo * 2);
                    HandValue.HighCard = (int)cards[4].CardNo;
                    return true;
                }
                else if (cards[0].CardNo == cards[1].CardNo && cards[3].CardNo == cards[4].CardNo)
                {
                    HandValue.Total = ((int)cards[1].CardNo * 2) + ((int)cards[3].CardNo * 2);
                    HandValue.HighCard = (int)cards[2].CardNo;
                    return true;
                }
                else if (cards[1].CardNo == cards[2].CardNo && cards[3].CardNo == cards[4].CardNo)
                {
                    HandValue.Total = ((int)cards[1].CardNo * 2) + ((int)cards[3].CardNo * 2);
                    HandValue.HighCard = (int)cards[0].CardNo;
                    return true;
                }
                return false;
            }

            private bool Pair()
            {
                // If hand contains one pair
                if (cards[0].CardNo == cards[1].CardNo)
                {
                    HandValue.Total = (int)cards[0].CardNo * 2;
                    HandValue.HighCard = (int)cards[4].CardNo;
                    return true;
                }
                else if (cards[1].CardNo == cards[2].CardNo)
                {
                    HandValue.Total = (int)cards[1].CardNo * 2;
                    HandValue.HighCard = (int)cards[4].CardNo;
                    return true;
                }
                else if (cards[2].CardNo == cards[3].CardNo)
                {
                    HandValue.Total = (int)cards[2].CardNo * 2;
                    HandValue.HighCard = (int)cards[4].CardNo;
                    return true;
                }
                else if (cards[3].CardNo == cards[4].CardNo)
                {
                    HandValue.Total = (int)cards[3].CardNo * 2;
                    HandValue.HighCard = (int)cards[2].CardNo;
                    return true;
                }

                return false;
            }

        }
}

