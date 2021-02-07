/*
 *  OOP III Final Project 
 *  
 *  Completed by Deanna, Praveen, Gowshigan, Rolando
 *  
 *  File: CardOutOfRangeException.cs
 * 
 *  Purpose: This file controls the Exception class and its respective abilities.
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_GUI
{
    public class CardOutOfRangeException : Exception
    {
        private CardList deckContents;
        public CardList DeckContents { get { return deckContents; } }
        public CardOutOfRangeException(CardList sourceDeckContents) : base("There are only 32 cards in the deck.") 
        { 
            deckContents = sourceDeckContents; 
        }
    }
}
