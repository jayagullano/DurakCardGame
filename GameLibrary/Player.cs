/*
 *  OOP III Final Project 
 *  
 *  Completed by Deanna, Praveen, Gowshigan, Rolando
 *  
 *  File: Player.cs
 * 
 *  Purpose: This file controls the player class and its respective abilities.
 * 
 */

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace Project_GUI
{

    public class Player
    {

        /// <summary>
        /// Instance Attributes
        /// </summary>
        protected String name;
        private CurrentHand hand;
        private bool isAttacking;
        private bool isDefending;
        
        /// <summary>
        /// Class attributes
        /// </summary>
        const String DEFAULT_NAME = "Jackson Pollock";
        const bool DEFAULT_ISATTACKING = true;
        const bool DEFAULT_ISDEFENDING = false;
        const CurrentHand DEFAULT_PLAYERHAND = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Player()
        {
            setName(DEFAULT_NAME);
            setHand(DEFAULT_PLAYERHAND);
            setIsAttacking(DEFAULT_ISATTACKING);
            setIsDefending(DEFAULT_ISDEFENDING);
        }

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hand"></param>
        /// <param name="isAttacking"></param>
        public Player(String name, CurrentHand hand, bool isAttacking)
        {
            setName(name);
            setHand(hand);
            setIsAttacking(isAttacking);
            if (isAttacking)
            {
                setIsDefending(false);
            } else
            {
                setIsDefending(true);
            }
        }

        /// <summary>
        /// Adds an attacking phase
        /// </summary>
        /// <param name="gameRiver"></param>
        /// <param name="attackingCard"></param>
        public void attack(River gameRiver, Card attackingCard, out bool isValid)
        {
            isValid = false;
            CardList list = new CardList();
            for (int i = 0; i < gameRiver.length(); i++)
            {
                list.Add(gameRiver.getCard(i));
            }

            if (gameRiver.length() == 0)
            {
                isValid = true;
                gameRiver.addCard(attackingCard);
                getHand().removeCard(attackingCard);

            } else if (gameRiver.length() == 2)
            {

                if (attackingCard.getCardRank() == list[0].rank
                        | attackingCard.getCardRank() == list[1].rank)
                {
                    isValid = true;
                    gameRiver.addCard(attackingCard);
                    getHand().removeCard(attackingCard);
                }

            } else if (gameRiver.length() == 4)
            {

                if (attackingCard.getCardRank() == list[0].rank
                        | attackingCard.getCardRank() == list[1].rank
                        | attackingCard.getCardRank() == list[2].rank
                        | attackingCard.getCardRank() == list[3].rank)
                {
                    isValid = true;
                    gameRiver.addCard(attackingCard);
                    getHand().removeCard(attackingCard);
                }

            } else if (gameRiver.length() == 6)
            {

                if (attackingCard.getCardRank() == list[0].rank
                        | attackingCard.getCardRank() == list[1].rank
                        | attackingCard.getCardRank() == list[2].rank
                        | attackingCard.getCardRank() == list[3].rank
                        | attackingCard.getCardRank() == list[4].rank
                        | attackingCard.getCardRank() == list[5].rank)
                {
                    isValid = true;
                    gameRiver.addCard(attackingCard);
                    getHand().removeCard(attackingCard);
                }

            } else if (gameRiver.length() == 8)
            {

                if (attackingCard.getCardRank() == list[0].rank
                        | attackingCard.getCardRank() == list[1].rank
                        | attackingCard.getCardRank() == list[2].rank
                        | attackingCard.getCardRank() == list[3].rank
                        | attackingCard.getCardRank() == list[4].rank
                        | attackingCard.getCardRank() == list[5].rank)
                {
                    isValid = true;
                    gameRiver.addCard(attackingCard);
                    getHand().removeCard(attackingCard);
                }
            }
        }

        /// <summary>
        /// Sets defending phase for the player
        /// </summary>
        /// <param name="gameRiver"></param>
        /// <param name="trumpCard"></param>
        /// <param name="defendingCard"></param>
        public void defend(River gameRiver, Card trumpCard, Card defendingCard, out bool isDefended)
        {
            //Card defendingCard = new Card();

            CardList list = new CardList();
            bool defended = false;
            for (int i = 0; i < gameRiver.length(); i++)
            {
                list.Add(gameRiver.getCard(i));
            }

            if(gameRiver.length() == 1)
            {

                if (defendingCard.getCardSuit() == list[0].suit
                        & defendingCard > list[0]
                        | defendingCard.getCardSuit() == trumpCard.getCardSuit()
                        & defendingCard > list[0])
                {
                    gameRiver.addCard(defendingCard);
                    getHand().removeCard(defendingCard);
                    defended = true;
                }

            } else if (gameRiver.length() == 3)
            {

                if (defendingCard.getCardSuit() == list[2].suit
                        & defendingCard > list[2]
                        | defendingCard.getCardSuit() == trumpCard.getCardSuit()
                        & defendingCard > list[2])
                {
                    gameRiver.addCard(defendingCard);
                    getHand().removeCard(defendingCard);
                    defended = true;
                }

            } else if (gameRiver.length() == 5)
            {

                if (defendingCard.getCardSuit() == list[4].suit
                        & defendingCard > list[4]
                        | defendingCard.getCardSuit() == trumpCard.getCardSuit()
                        & defendingCard > list[4])
                {
                    gameRiver.addCard(defendingCard);
                    getHand().removeCard(defendingCard);
                    defended = true;
                }

            } else if (gameRiver.length() == 7)
            {
                if (defendingCard.getCardSuit() == list[6].suit
                        & defendingCard > list[6]
                        | defendingCard.getCardSuit() == trumpCard.getCardSuit()
                        & defendingCard > list[6])
                {
                    gameRiver.addCard(defendingCard);
                    getHand().removeCard(defendingCard);
                    defended = true;
                }
            }
            isDefended = defended;
        }

        /// <summary>
        /// Returns the current players information (name, etc)
        /// </summary>
        /// <returns></returns>
        override
        public String ToString()
        {
            String returnString = "";
            String isAttacking = "";
            if (getIsAttacking())
            {
                isAttacking = "Yes";
            } else
            {
                isAttacking = "No";
            }

            returnString += "\n" + " "
                + getHand().ToString(getHand(), getName())
                + "\nIs this player attacking? : "
                + isAttacking; 

            return returnString;
        }

        /// <summary>
        /// Sets the hand
        /// </summary>
        /// <param name="deck"></param>
        public void deal(Deck deck)
        {
            CardList cards = deck.DrawCards(6 - hand.length());
            hand.addCards(cards);
        }

        /// <summary>
        /// Getter function
        /// </summary>
        /// <returns></returns>
        public String getName() { return name; }

        /// <summary>
        /// Setter function
        /// </summary>
        /// <param name="name"></param>
        public void setName(String name) { this.name = name; }

        /// <summary>
        /// Getter function
        /// </summary>
        /// <returns></returns>
        public CurrentHand getHand() { return hand; }

        /// <summary>
        /// Setter function
        /// </summary>
        /// <param name="hand"></param>
        public void setHand(CurrentHand hand) { this.hand = hand; }

        /// <summary>
        /// Returns the value of if the current user is attacking
        /// </summary>
        /// <returns></returns>
        public bool getIsAttacking() { return isAttacking; }

        /// <summary>
        /// Sets the variable to determine if the user is attacking
        /// </summary>
        /// <param name="isAttacking"></param>
        public void setIsAttacking(bool isAttacking) { this.isAttacking = isAttacking; }

        /// <summary>
        /// Returns the variable to determine if the user is defending
        /// </summary>
        /// <returns></returns>
        public bool getIsDefending() { return isDefending; }

        /// <summary>
        /// Sets the variable to determine if the user is defending
        /// </summary>
        /// <param name="isDefending"></param>
        public void setIsDefending(bool isDefending) { this.isDefending = isDefending; }
    }
}