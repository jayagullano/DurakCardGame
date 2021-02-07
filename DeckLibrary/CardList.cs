/*
 *  OOP III Final Project 
 *  
 *  Completed by Deanna, Praveen, Gowshigan, Rolando
 *  
 *  File: CardList.cs
 * 
 *  Purpose: This file controls the structure of the cards 
 *           to populate the game.
 * 
 */

using System;

using System.Collections;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Windows.Forms;


namespace Project_GUI

{

    public class CardList : List<Card>, ICloneable
    {

        /// <summary>
        /// Returns a cloned card list
        /// </summary>
        /// <returns>newCards</returns>
        public object Clone()
        {
            CardList cards = new CardList();
            foreach (Card sourceCard in this)
            {
                cards.Add((Card)sourceCard.Clone());
            }
            return cards;
        }

        /// <summary>
        /// Copies the current cardList cards
        /// </summary>
        /// <param name="targetCards"></param>
        public void CopyTo(CardList targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }
    }
}

