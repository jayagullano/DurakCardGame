/*  OOP III Final Project 
*  
*  Completed by Deanna, Praveen, Gowshigan, Rolando
*  
*  File: ComputerAI.cs
* 
*  Purpose: This file controls the hand of the (Or Computer).
* 
*/

using System;

namespace Project_GUI
{
    public class ComputerAI : Player
    {
        public ComputerAI() {}

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="hand"></param>
        /// <param name="isAttackTrue"></param>
        public ComputerAI(String name, CurrentHand hand, bool isAttackTrue)
        {
            setName(name);
            setHand(hand);
            setIsAttacking(isAttackTrue);
            if (!isAttackTrue)
                setIsDefending(true);
            else
                setIsDefending(false);
        }

        /// <summary>
        /// Responsible to initiate the attack
        /// </summary>
        /// <param name="gameRiver"></param>
        public void attack(River gameRiver)
        {
            Card attack = new Card();
            CardList list = new CardList();
            bool isAttack = false;
            for (int i = 0; i < gameRiver.length(); i++)
            {
                list.Add(gameRiver.getCard(i));
            }

            if(gameRiver.length() == 0)
            {
                for (int i = 0; i < getHand().length(); i++)
                {
                    attack = getHand().determineCard(i);

                    gameRiver.addCard(attack);
                    getHand().removeCard(attack);
                    isAttack = true;
                }
            } else if (gameRiver.length() == 2)
            {
                for (int i = 0; i < getHand().length(); i++)
                {
                    attack = getHand().determineCard(i);

                    if (attack.getCardRank() == list[0].rank 
                        | attack.getCardRank() == list[1].rank)
                    {
                        gameRiver.addCard(attack);
                        getHand().removeCard(attack);
                        isAttack = true;
                    }
                }

            } else if (gameRiver.length() == 4)
            {
                for (int i = 0; i < getHand().length(); i++)
                {
                    attack = getHand().determineCard(i);

                    if (attack.getCardRank() == list[0].rank 
                        | attack.getCardRank() == list[1].rank 
                        | attack.getCardRank() == list[2].rank 
                        | attack.getCardRank() == list[3].rank)
                    {
                        gameRiver.addCard(attack);
                        getHand().removeCard(attack);
                        isAttack = true;
                    }
                }

            } else if (gameRiver.length() == 6)
            {
                for (int i = 0; i < getHand().length(); i++)
                {
                    attack = getHand().determineCard(i);

                    if (attack.getCardRank() == list[0].rank 
                        | attack.getCardRank() == list[1].rank 
                        | attack.getCardRank() == list[2].rank 
                        | attack.getCardRank() == list[3].rank 
                        | attack.getCardRank() == list[4].rank 
                        | attack.getCardRank() == list[5].rank)
                    {
                        gameRiver.addCard(attack);
                        getHand().removeCard(attack);
                        isAttack = true;
                    }
                }
            } else if (gameRiver.length() == 8)
            {
                for (int i = 0; i < getHand().length(); i++)
                {
                    attack = getHand().determineCard(i);

                    if (attack.getCardRank() == list[0].rank 
                        | attack.getCardRank() == list[1].rank 
                        | attack.getCardRank() == list[2].rank 
                        | attack.getCardRank() == list[3].rank 
                        | attack.getCardRank() == list[4].rank 
                        | attack.getCardRank() == list[5].rank)
                    {
                        gameRiver.addCard(attack);
                        getHand().removeCard(attack);
                        isAttack = true;
                    }
                }
            }

            if (isAttack == false && gameRiver.length() == 0 
                | gameRiver.length() == 2 
                | gameRiver.length() == 4 
                | gameRiver.length() == 6 
                | gameRiver.length() == 8)
            {
                setIsDefending(true);
                setIsAttacking(false);
            }
        }

        /// <summary>
        /// Responsible for controlling defending
        /// </summary>
        /// <param name="gameRiver"></param>
        /// <param name="trumpCard"></param>
        public void defend(River gameRiver, Card trumpCard, out int defendingCard)
        {
            defendingCard = 0; //Will be used to remove card on oppositions side
            Card defend = new Card();
            CardList list = new CardList();
            bool isDefense = false;

            for (int i = 0; i < gameRiver.length(); i++)
            {
                list.Add(gameRiver.getCard(i));
            }

            if(gameRiver.length() == 1)
            {
                for (int i = 0; i < getHand().length(); i++)
                {
                    defend = getHand().determineCard(i);

                    if (defend.getCardSuit() == list[0].suit 
                        & defend > list[0] 
                        | defend.getCardSuit() == trumpCard.getCardSuit() 
                        & defend > list[0])
                    {
                        defendingCard = i;
                        gameRiver.addCard(defend);
                        getHand().removeCard(defend);
                        isDefense = true;
                    }

                }

            } else if (gameRiver.length() == 3)
            {
                for (int i = 0; i < getHand().length(); i++)
                {
                    defend = getHand().determineCard(i);

                    if (defend.getCardSuit() == list[2].suit 
                        & defend > list[2] 
                        | defend.getCardSuit() == trumpCard.getCardSuit() 
                        & defend > list[2])
                    {
                        defendingCard = i;
                        gameRiver.addCard(defend);
                        getHand().removeCard(defend);
                        isDefense = true;
                    }
                }

            } else if (gameRiver.length() == 5)
            {
                for (int i = 0; i < getHand().length(); i++)
                {
                    defend = getHand().determineCard(i);

                    if (defend.getCardSuit() == list[4].suit 
                        & defend > list[4] 
                        | defend.getCardSuit() == trumpCard.getCardSuit() 
                        & defend > list[4])
                    {
                        defendingCard = i;
                        gameRiver.addCard(defend);
                        getHand().removeCard(defend);
                        isDefense = true;
                    }

                }
            } else if (gameRiver.length() == 7)
            {
                //AI chooses a card 
                for (int i = 0; i < getHand().length(); i++)
                {
                    defend = getHand().determineCard(i);

                    if (defend.getCardSuit() == list[6].suit 
                        & defend > list[6] 
                        | defend.getCardSuit() == trumpCard.getCardSuit() 
                        & defend > list[6])
                    {
                        defendingCard = i;
                        gameRiver.addCard(defend);
                        getHand().removeCard(defend);
                        isDefense = true;
                    }
                }
            }

            if (isDefense == false && gameRiver.length() == 1 
                | gameRiver.length() == 3 
                | gameRiver.length() == 5 
                | gameRiver.length() == 7)
            {
                setIsAttacking(true);
                setIsDefending(false);
            }
        }
    }
}

