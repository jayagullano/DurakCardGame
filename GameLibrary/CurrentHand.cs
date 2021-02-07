/*
 *  OOP III Final Project 
 *  
 *  Completed by Deanna, Praveen, Gowshigan, Rolando
 *  
 *  File: PlayerHand.cs
 * 
 *  Purpose: This file controls the hand of the player (Or Computer).
 * 
 */
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Project_GUI
{
    public class CurrentHand : ICloneable
    {
        /// <summary>
        /// Instance value initializes a new cardlist
        /// </summary>
        CardList thisHand = new CardList();

        /// <summary>
        /// Shows the available amount of cards 
        /// </summary>
        private int cardsRemainder;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public CurrentHand() { this.cardsRemainder = 0; }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="newPlayerHand"></param>
        private CurrentHand(CardList hand) { thisHand = hand; }

        /// <summary>
        /// Clones the current hand
        /// </summary>
        /// <returns>object</returns>
        public object Clone()
        {
            CurrentHand returnHand = new CurrentHand(thisHand.Clone() as CardList);
            return returnHand;
        }

        /// <summary>
        /// Adds cards to hand via entire CardList 
        /// </summary>
        /// <param name="cards"></param>
        public void addCards(CardList inputList)
        {
            for (int i = 0; i < inputList.Count(); i++)
            {
                thisHand.Add(inputList[i]);
            }
            cardsRemainder = thisHand.Count();
        }

        /// <summary>
        /// Removes a card from the users hand
        /// </summary>
        /// <param name="card"></param>
        public void removeCard(Card card)
        {
            thisHand.Remove(card);
            cardsRemainder = thisHand.Count();
        }

        /// <summary>
        /// Returns the length of the players hand
        /// </summary>
        /// <returns>thisHand.Count()</returns>
        public int length() { return thisHand.Count(); }

        /// <summary>
        /// Sets the users choice of card from the existing hand and return that object 
        /// </summary>
        /// <param name="choosenCardNumber"></param>
        /// <returns></returns>
        public Card determineCard(int cardNumber)
        {
            Card card;
            card = thisHand.ElementAt(cardNumber);
            //thisHand.Remove(card);
            return card;
        }

        /// <summary>
        /// Returns the numerical value of a card
        /// </summary>
        /// <param name="cardNum"></param>
        /// <returns>thisHand[cardNum]</returns>
        public Card getCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
                return thisHand[cardNum];
            else
                return null;
        }

        /// <summary>
        /// Shows the players hand
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="playerName"></param>
        /// <returns></returns>
        public String ToString(CurrentHand hand, String playerName)
        {
            String outValue = "";
            outValue += playerName.ToString() + "'s Cards: \n\n";
            for (int i = 0; i < hand.length(); i++)
            {
                Card temp = hand.getCard(i);
                outValue += temp.ToString();
                if (i != 51)
                    outValue += ", \n";
            }
            return outValue;

        }
    }
}

