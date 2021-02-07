/*
 *  OOP III Final Project 
 *  
 *  Completed by Deanna, Praveen, Gowshigan, Rolando
 *  
 *  File: GameDeck.cs
 * 
 *  Purpose: This file controls the deck for gameplay.
 * 
 */
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;



namespace Project_GUI

{

    //public GameDeck class, utlizes ICloneable interface

    public class Deck : ICloneable

    {

        /// <summary>
        /// Instance Variables for the Deck class.
        /// </summary>
        private CardList cardList = new CardList();
        private int cardListRemaining = 0;
        private Card trumpCard = new Card();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Deck()
        {
            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = 2; rank  <= 14; rank++)
                {
                    cardList.Add(new Card((Suit)suit, (Rank)rank));
                }
            }
        }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="deckSize"></param>
        public Deck(int deckSize)
        {
            int initial = 0;
            if (deckSize == 52)
            {
                initial = 1;
            }
            else if (deckSize == 36) 
            {
                initial = 6;
                cardList.Add(new Card((Suit)0, (Rank)14));
                cardList.Add(new Card((Suit)1, (Rank)14));
                cardList.Add(new Card((Suit)2, (Rank)14));
                cardList.Add(new Card((Suit)3, (Rank)14));
            }
            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = initial; rank < 14; rank++)
                {
                    cardList.Add(new Card((Suit)suit, (Rank)rank));
                }
            }

        }

        /// <summary>
        /// Sets a game deck inputted by a cardlist
        /// </summary>
        /// <param name="newCards"></param>
        private Deck(CardList newCards)
        {
            cardList = newCards;
        }

        /// <summary>
        /// Parameterized Constructor allowing for trump cardList
        /// </summary>
        /// <param name="useTrumps"></param>
        /// <param name="trump"></param>
        public Deck(bool useTrumps, Suit trump) : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        /// <summary>
        /// Overloaded function allowing to set Ace as high, and trumps
        /// </summary>
        /// <param name="isAceHigh"></param>
        /// <param name="useTrumps"></param>
        /// <param name="trump"></param>
        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        /// <summary>
        /// Clones the deck
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Deck newDeck = new Deck(cardList.Clone() as CardList);
            return newDeck;
        }

        /// <summary>
        /// Shuffle() will automatically shuffle a set amount of 36 cardList
        /// </summary>
        public void Shuffle()
        {
            CardList newDeck = new CardList();
            bool[] assigned = new bool[36]; //Setting to 36 as that is max deck size
            Random randomNum = new Random();
            for (int i = 0; i < 36; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = randomNum.Next(36);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cardList[sourceCard]);
            }
            newDeck.CopyTo(cardList);
        }

        /// <summary>
        /// Returns the remaining cardList in the deck
        /// </summary>
        /// <returns></returns>
        public int getCardsRemaining()
        {
            return cardListRemaining = cardList.Count;
        }

        /// <summary>
        /// Returns the trump card
        /// </summary>
        /// <returns></returns>
        public Card getTrumpCard()
        {
            return trumpCard;
        }

        /// <summary>
        /// Sets the trump card
        /// </summary>
        /// <param name="deck"></param>
        public void setTrumpCard(Deck deck)
        {
            Card trumpCard;
            trumpCard = deck.DrawCard();
            this.trumpCard = trumpCard;
        }
        
        /// <summary>
        /// Returns a card from the given integer value
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns></returns>
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
                return cardList[cardNum];
            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum,
                       "Value must be between 0 and 51."));
        }

        /// <summary>
        /// Returns a card from the deck to the players hand
        /// </summary>
        /// <returns></returns>
        public Card DrawCard()
        {
            Card card;
            card = cardList.First();
            cardList.RemoveAt(0);
            return card;
        }

        /// <summary>
        /// Returns list values of cardList
        /// </summary>
        /// <param name="numberOfCards"></param>
        /// <returns></returns>
        public CardList DrawCards(int numberOfCards)
        {
            CardList cardListdrawn = new CardList();
            for (int i = 0; i < numberOfCards; i++)
            {
                cardListdrawn.Add(cardList.ElementAt(0));
                cardList.RemoveAt(0);
            }
            return cardListdrawn;
        }

        /// <summary>
        /// Returns the current length of the deck
        /// </summary>
        /// <returns></returns>
        public int length()
        {
            return cardList.Count();
        }

        /// <summary>
        /// Shows the deck
        /// </summary>
        /// <param name="gameDeck1"></param>
        /// <returns></returns>
        public String ToString(Deck gameDeck1)
        {
            String returnString = "";

            returnString += "\n\nDeckCards\n";

            for (int i = 0; i < gameDeck1.length(); i++)

            {

                Card tempCard = gameDeck1.GetCard(i);

                returnString += tempCard.ToString();

                if (i != 51)

                    returnString += ", ";

            }
            return returnString;
        }

    }

}

