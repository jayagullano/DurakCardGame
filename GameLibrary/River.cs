/*
 *  OOP III Final Project 
 *  
 *  Completed by Deanna, Praveen, Gowshigan, Rolando
 *  
 *  File: GameRiver.cs
 * 
 *  Purpose: This file controls the section in which the cards are place
 *           during the initiated game.
 * 
 */

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Project_GUI
{
    public class River : ICloneable
    {
        //instance attributes
        CardList gameRiver = new CardList();
        private int riverRemainder = 0;

        /// <summary>
        /// Returns the remaining cards in the River
        /// </summary>
        /// <returns></returns>
        public int getCardsRemaining() { return riverRemainder = gameRiver.Count; }

        /// <summary>
        /// AddCardToRiver adds the inputted card to the display
        /// </summary>
        /// <param name="card"></param>
        public void addCard(Card card)
        {
            gameRiver.Add(card);
            riverRemainder = gameRiver.Count();
        }

        /// <summary>
        /// Returns the entire river
        /// </summary>
        /// <returns>gameRiver</returns>
        public CardList getAll()
        {
            return gameRiver;
        }
        /// <summary>
        /// Removes the existing card from the river
        /// </summary>
        /// <param name="card"></param>
        public void removeCard(Card card)
        {
            gameRiver.Remove(card);
            riverRemainder = gameRiver.Count();
        }
        
        /// <summary>
        /// Returns the length of the current river
        /// </summary>
        /// <returns></returns>
        public int length()
        {
            return gameRiver.Count();
        }

        /// <summary>
        /// Returns the integer value of the card on the river
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns></returns>
        public Card getCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)

                return gameRiver[cardNum];

            else
                throw (new System.ArgumentOutOfRangeException("cardNum", cardNum,
                       "Value must be between 0 and 51."));
        }

        /// <summary>
        /// Clones the river cards
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            River river = new River(gameRiver.Clone() as CardList);
            return river;
        }

        /// <summary>
        /// Sets the game river card
        /// </summary>
        /// <param name="river"></param>
        private River(CardList river)
        {
            gameRiver = river;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public River() { }

        /// <summary>
        /// Clears the river
        /// </summary>
        public void ClearRiver() { gameRiver.Clear(); }

        /// <summary>
        /// Sends the river to string
        /// </summary>
        /// <param name="river"></param>
        /// <returns></returns>
        public String ToString(River river)
        {
            String returnString = "";
            returnString += "\n\n\tRiverCards\n\t";
            for (int i = 0; i < river.length(); i++)
            {
                Card tempCard = river.getCard(i);
                returnString += tempCard.ToString();
                if (i != 51)
                    returnString += ", ";
            }
            return returnString;
        }


    }

}

