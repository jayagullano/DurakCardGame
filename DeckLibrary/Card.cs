

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;



namespace Project_GUI

{

    public class Card : ICloneable

    {

        /// <summary>
        /// Instance Attributes
        /// </summary>
        public readonly Rank rank;

        public readonly Suit suit;

        /// <summary>
        /// Class attributes
        /// </summary>
        public static bool isAceHigh = true;

        public static bool useTrumps = false;

        public static Suit trump = Suit.Club;



        public EventHandler CardClicked { get; set; }



        /// <summary>
        /// Default Constructor
        /// </summary>
        public Card() {}


        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="newSuit"></param>
        /// <param name="newRank"></param>
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        /// <summary>
        /// Will set the card based on passing another card
        /// </summary>
        /// <param name="inputCard"></param>
        public Card(Card inputCard)
        {
            suit = inputCard.getCardSuit();
            rank = inputCard.getCardRank();
        }


        /// <summary>
        /// returns the Card Suit
        /// </summary>
        /// <returns></returns>
        public Suit getCardSuit()
        {
            return suit;
        }


        /// <summary>
        /// Returns the card Rank
        /// </summary>
        /// <returns></returns>
        public Rank getCardRank()
        {
            return rank;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return MemberwiseClone();
        }


        /// <summary>
        /// Simple toString()
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }


        /// <summary>
        /// Return the card via integer value
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <returns></returns>
        public String ToString(int playerNumber)
        {
            return "\nCard Drawn Player " + playerNumber + "\nThe " + rank + " of " + suit + "s";
        }


        /// <summary>
        /// Returns hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 13 * (int)suit + (int)rank;
        }


        /// <summary>
        /// Overloaded == operator to compare cards
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.suit == card2.suit) && (card1.rank == card2.rank);
        }

        /// <summary>
        /// Overloaded != operator
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        /// <summary>
        /// Compares value of object in terms of Card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public override bool Equals(object card)
        {
            return this == (Card)card;
        }

        /// <summary>
        /// Overloaded > operator
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator >(Card firstCard, Card secondCard)
        {
            if (firstCard.suit == secondCard.suit)
            {
                if (isAceHigh)
                {
                    if (firstCard.rank == Rank.Ace)
                    {
                        if (secondCard.rank == Rank.Ace)
                            return false;
                        else
                            return true;
                    }
                    else
                    {
                        if (secondCard.rank == Rank.Ace)
                            return false;
                        else
                            return (firstCard.rank > secondCard.rank);
                    }
                }
                else
                {
                    return (firstCard.rank > secondCard.rank);
                }
            }
            else
            {
                if (useTrumps && (secondCard.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }
        
        /// <summary>
        /// Overloaded < operator
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator <(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }

        /// <summary>
        /// Overloaded >= Operator
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator >=(Card firstCard, Card secondCard)
        {
            if (firstCard.suit == secondCard.suit)
            {
                if (isAceHigh)
                {
                    if (firstCard.rank == Rank.Ace)
                    {
                        return true;
                    }
                    else
                    {
                        if (secondCard.rank == Rank.Ace)
                            return false;
                        else
                            return (firstCard.rank >= secondCard.rank);
                    }
                }
                else
                {
                    return (firstCard.rank >= secondCard.rank);
                }
            }
            else
            {
                if (useTrumps && (secondCard.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// Overloaded <= operator
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 > card2);
        }

    }

}

