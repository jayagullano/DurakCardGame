using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_GUI;
using MyCardBox;
using DemoCardsLibrary;

/*
 *  OOP III Final Project 
 *  
 *  Completed by Deanna, Praveen, Gowshigan, Rolando
 *  Date Completed: April 17, 2020
 *  File: DurakGame.cs
 *  
 *  Purpose: This file controls the gameplay for Durak.
 *  
 *  Implementations: GameLog and Transferring Durak
 * 
 */
namespace Project_GUI
{
    public partial class DurakGame : Form
    {

        #region Class Variables
        //Game is loaded
        //Instantiate Required Elements For program
        Deck gameDeck;

        static PictureBox[] myBox = new PictureBox[10];
        private static CurrentHand playerOneHand;
        private static CurrentHand playerTwoHand;
        Player playerOne;
        ComputerAI playerTwo;
        GameLog gameLog;
        static CardList playerOneHandDisplay;
        static CardList playerTwoHandDisplay;
        static CardList riverDisplay;
        CardList trumpCardDisplayList = new CardList();
        
        //Instantiate the river 
        static River gameRiver;

        const String DEFENDER = "Defender";
        const String ATTACKER = "Attacker";

        static int roundNumber;

        #endregion
        #region Initial Game Startup
        public DurakGame() { InitializeComponent(); }

        /// <summary>
        /// Will instantiate the game when loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DurakGame_Load(object sender, EventArgs e)
        {
            
            //Hide unnecessary elements before the game is started
            pbP1Card1.Hide();
            pbP1Card2.Hide();
            pbP1Card3.Hide();
            pbP1Card4.Hide();
            pbP1Card5.Hide();
            pbP1Card6.Hide();

            pbP2Card1.Hide();
            pbP2Card2.Hide();
            pbP2Card3.Hide();
            pbP2Card4.Hide();
            pbP2Card5.Hide();
            pbP2Card6.Hide();

            lblNumOfCards1.Hide();
            lblNumOfCards2.Hide();
            lblRiverCards.Hide();

            btnClearLog.Hide();
            btnShowLog.Hide();
            btnTransfer.Hide();

            btnEnd.Hide();
            btnTake.Hide();

            lblTrump.Hide();
            pbTrump.Hide();
        }
        #endregion
        #region Game Controls
        /// <summary>
        /// When the player initializes the game, instantiate variables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            gameLog = new GameLog();
            myBox[0] = pbRiver1;
            myBox[1] = pbRiver2;
            myBox[2] = pbRiver3;
            myBox[3] = pbRiver4;
            myBox[4] = pbRiver5;
            myBox[5] = pbRiver6;
            myBox[6] = pbRiver7;
            myBox[7] = pbRiver8;
            myBox[8] = pbRiver9;
            myBox[9] = pbRiver10;
            riverDisplay = new CardList();
            gameRiver = new River();
            gameDeck = new Deck(36);
            playerOneHand = new CurrentHand();
            playerTwoHand = new CurrentHand();
            playerOne = new Player("Player 1", playerOneHand, true);
            playerTwo = new ComputerAI("Player 2", playerTwoHand, false);
            playerOneHandDisplay = new CardList();
            playerTwoHandDisplay = new CardList();

            //Initiate the new game and show elements to the user
            btnNewGame.Hide();
            pbP1Card1.Show();
            pbP1Card2.Show();
            pbP1Card3.Show();
            pbP1Card4.Show();
            pbP1Card5.Show();
            pbP1Card6.Show();

            pbP2Card1.Show();
            pbP2Card2.Show();
            pbP2Card3.Show();
            pbP2Card4.Show();
            pbP2Card5.Show();
            pbP2Card6.Show();

            lblTrump.Show();
            pbTrump.Show();

            lblNumOfCards1.Show();
            lblNumOfCards2.Show();
            lblRiverCards.Show();

            btnShowLog.Show();
            btnClearLog.Show();
            btnTransfer.Show();
            btnTransfer.Enabled = false;

            //Shuffle Deck
            gameDeck.Shuffle();

            gameDeck.setTrumpCard(gameDeck);

            string value = "";
            pbTrump.Image = returnImage(gameDeck.getTrumpCard(), out value);

            //Add Cards to the users hands
            playerOne.deal(gameDeck);
            playerTwo.deal(gameDeck);

            lblPosition1.Text = ATTACKER;
            lblPosition2.Text = DEFENDER;

            btnEnd.Show();
            btnTake.Show();

            DisplayPlayerOneHand();
            DisplayPlayerTwoHand();

            DisplayCounts();
        }

        /// <summary>
        /// Will take all cards from the river and add it to the users hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTake_Click(object sender, EventArgs e)
        {
            playerOne.getHand().addCards(gameRiver.getAll());
        }

        /// <summary>
        /// Will control the each players card choice
        /// </summary>
        /// <param name="card"></param>
        private void PlayMove(int card)
        {
            bool isValid;
            if (playerOne.getIsAttacking())
            {
                playerOne.attack(gameRiver, playerOne.getHand().determineCard(card), out isValid);
                int defense;
                playerTwo.defend(gameRiver, gameDeck.getTrumpCard(), out defense);
                DisplayRiverCards();
                DisplayCounts();
                //If card is accepted
                if (isValid)
                {
                    //Hides player's choice of card
                    HidePlayerOne(card);
                    //Hides the defended card chosen by the computer
                    HidePlayerTwo(defense);
                
                    pbP1Card1.Enabled = true;
                    pbP1Card2.Enabled = true;
                    pbP1Card3.Enabled = true;
                    pbP1Card4.Enabled = true;
                    pbP1Card5.Enabled = true;
                    pbP1Card6.Enabled = true;

                }
            } else if (playerOne.getIsDefending()){

                //If player one is defending, determine if a transfer can be played
                if(determineDurak(playerOne, gameRiver))
                {
                    btnTransfer.Enabled = true;
                } else
                {
                    btnTransfer.Enabled = false;
                }

                bool isPlayerOneDefended;
                playerOne.defend(gameRiver, gameDeck.getTrumpCard(), playerOne.getHand().determineCard(card), out isPlayerOneDefended);
                int isPlayerTwoDefended;
                playerTwo.defend(gameRiver, gameDeck.getTrumpCard(), out isPlayerTwoDefended);

                //If playerTwo is finished attacking
                if(playerTwo.getIsDefending() == false)
                {
                    //Increment round
                    roundNumber++;

                    //Log round
                    gameLog.LogRound(gameLog, roundNumber, playerOne, playerTwo, gameRiver);

                    //Set the player one to attacking
                    playerOne.setIsAttacking(true);
                }
            }
        }

        /// <summary>
        /// Will instantiate each players deck and readd cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            //If the player was attacking, set the player two as attacking and set player one as defending
            if (playerOne.getIsAttacking())
            {
                //Set player one to defending,
                playerOne.setIsAttacking(false);

                //Set player two as attacking
                playerTwo.setIsAttacking(true);

                //Set the label for player one as defending and player two as attacking
                lblPosition1.Text = DEFENDER;
                lblPosition2.Text = ATTACKER;

                //Disengage the end button
                btnEnd.Enabled = false;

            } else
            {
                //Set player one to attacking,
                playerOne.setIsAttacking(true);

                //Set player two as defending
                playerTwo.setIsAttacking(false);

                //Set the label for player one as defending and player two as attacking
                lblPosition1.Text = ATTACKER;
                lblPosition2.Text = DEFENDER;
            }

            //Add Cards to the users hands
            playerOne.deal(gameDeck);
            playerTwo.deal(gameDeck);

            pbP1Card1.Show();
            pbP1Card2.Show();
            pbP1Card3.Show();
            pbP1Card4.Show();
            pbP1Card5.Show();
            pbP1Card6.Show();

            pbP2Card1.Show();
            pbP2Card2.Show();
            pbP2Card3.Show();
            pbP2Card4.Show();
            pbP2Card5.Show();
            pbP2Card6.Show();

            DisplayPlayerOneHand();
            DisplayPlayerTwoHand();

            DisplayCounts();
        }
        #endregion
        #region Card Event Handlers

        /// <summary>
        /// Determines if the first card was picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbP1Card1_Click(object sender, EventArgs e)
        {
            PlayMove(0);
            pbP1Card2.Enabled = false;
            pbP1Card3.Enabled = false;
            pbP1Card4.Enabled = false;
            pbP1Card5.Enabled = false;
            pbP1Card6.Enabled = false;
        }

        /// <summary>
        /// Determines if the card was picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbP1Card2_Click(object sender, EventArgs e)
        {
            PlayMove(1);
            pbP1Card1.Enabled = false;
            pbP1Card3.Enabled = false;
            pbP1Card4.Enabled = false;
            pbP1Card5.Enabled = false;
            pbP1Card6.Enabled = false;
        }

        /// <summary>
        /// Determines if the card was picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbP1Card3_Click(object sender, EventArgs e)
        {
            PlayMove(2);
            pbP1Card2.Enabled = false;
            pbP1Card1.Enabled = false;
            pbP1Card4.Enabled = false;
            pbP1Card5.Enabled = false;
            pbP1Card6.Enabled = false;
        }

        /// <summary>
        /// Determines if the card was picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbP1Card4_Click(object sender, EventArgs e)
        {
            PlayMove(3);
            pbP1Card2.Enabled = false;
            pbP1Card3.Enabled = false;
            pbP1Card1.Enabled = false;
            pbP1Card5.Enabled = false;
            pbP1Card6.Enabled = false;
        }

        /// <summary>
        /// Determines if the card was picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbP1Card5_Click(object sender, EventArgs e)
        {
            PlayMove(4);
            pbP1Card2.Enabled = false;
            pbP1Card3.Enabled = false;
            pbP1Card4.Enabled = false;
            pbP1Card1.Enabled = false;
            pbP1Card6.Enabled = false;
        }

        /// <summary>
        /// Determines if the card was picked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbP1Card6_Click(object sender, EventArgs e)
        {
            PlayMove(5);
            pbP1Card2.Enabled = false;
            pbP1Card3.Enabled = false;
            pbP1Card4.Enabled = false;
            pbP1Card5.Enabled = false;
            pbP1Card1.Enabled = false;
        }

        /// <summary>
        /// NO use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbP2Card1_Click(object sender, EventArgs e) { }
        private void pbP2Card2_Click(object sender, EventArgs e) { }
        private void pbP2Card3_Click(object sender, EventArgs e) { }
        private void pbP2Card4_Click(object sender, EventArgs e) { }
        private void pbP2Card5_Click(object sender, EventArgs e) { }
        private void pbP2Card6_Click(object sender, EventArgs e) { }

        #endregion
        #region Client Display 

        /// <summary>
        /// Hides Players One's cards
        /// </summary>
        /// <param name="card"></param>
        private void HidePlayerOne(int card)
        {
            //Will hide the card that was chosen
            if (card == 0)
            {
                pbP1Card1.Hide();
                lblCard1.Text = "";
            }
            else if (card == 1)
            {
                pbP1Card2.Hide();
                lblCard2.Text = "";
            }
            else if (card == 2)
            {
                pbP1Card3.Hide();
                lblCard3.Text = "";
            }
            else if (card == 3)
            {
                pbP1Card4.Hide();
                lblCard4.Text = "";
            }
            else if (card == 4)
            {
                pbP1Card5.Hide();
                lblCard5.Text = "";
            }
            else if (card == 5)
            {
                pbP1Card6.Hide();
                lblCard6.Text = "";
            }
        }

        /// <summary>
        /// Hides the playerTwo's cards
        /// </summary>
        /// <param name="card"></param>
        private void HidePlayerTwo(int card)
        {
            //Will hide the card that was chosen on the players side
            if (card == 0)
            {
                pbP2Card1.Hide();
            }
            else if (card == 1)
            {
                pbP2Card2.Hide();
            }
            else if (card == 2)
            {
                pbP2Card3.Hide();
            }
            else if (card == 3)
            {
                pbP2Card4.Hide();
            }
            else if (card == 4)
            {
                pbP2Card5.Hide();
            }
            else if (card == 5)
            {
                pbP2Card6.Hide();
            }
        }
        /// <summary>
        /// Will output to the user the number of cards in each hand and in the river
        /// </summary>
        private void DisplayCounts()
        {
            lblNumOfCards1.Text = "Number Of Cards: " + playerOne.getHand().length();
            lblNumOfCards2.Text = "Number Of Cards: " + playerTwo.getHand().length();
            lblRiverCards.Text = "Number of River: " + gameRiver.getCardsRemaining();
            lblCardCount.Text = gameDeck.getCardsRemaining() + "";
        }

        /// <summary>
        /// Displays player ones hand
        /// </summary>
        public void DisplayPlayerOneHand()
        {
            //PlayerOne Display Cards
            playerOneHandDisplay.Clear();

            DisplayCounts();
            for (int i = 0; i < playerOne.getHand().length(); i++)
            {
                playerOneHandDisplay.Add(playerOne.getHand().getCard(i));
            }

            string value = "";
            pbP1Card1.Image = returnImage(playerOneHandDisplay[0], out value);
            lblCard1.Text = value;
            pbP1Card2.Image = returnImage(playerOneHandDisplay[1], out value);
            lblCard2.Text = value;
            pbP1Card3.Image = returnImage(playerOneHandDisplay[2], out value);
            lblCard3.Text = value;
            pbP1Card4.Image = returnImage(playerOneHandDisplay[3], out value);
            lblCard4.Text = value;
            pbP1Card5.Image = returnImage(playerOneHandDisplay[4], out value);
            lblCard5.Text = value;
            pbP1Card6.Image = returnImage(playerOneHandDisplay[5], out value);
            lblCard6.Text = value;
        }

        /// <summary>
        /// Displays player twos hands
        /// </summary>
        public void DisplayPlayerTwoHand()
        {
            //PlayerOne Display Cards
            playerTwoHandDisplay.Clear();

            DisplayCounts();
            for (int i = 0; i < playerTwo.getHand().length(); i++)
            {
                playerTwoHandDisplay.Add(playerTwo.getHand().getCard(i));
            }

            pbP2Card1.Image = Properties.Resources.Back;
            pbP2Card2.Image = Properties.Resources.Back;
            pbP2Card3.Image = Properties.Resources.Back;
            pbP2Card4.Image = Properties.Resources.Back;
            pbP2Card5.Image = Properties.Resources.Back;
            pbP2Card6.Image = Properties.Resources.Back;
        }

        /// <summary>
        /// Display the river cards to the user
        /// </summary>
        public void DisplayRiverCards()
        {
            String value;

            //Clears existing river
            pnlRiver.Controls.Clear();
            riverDisplay.Clear();

            for (int i = 0; i < gameRiver.length(); i++)
            {
                riverDisplay.Add(gameRiver.getCard(i));
            }

            for(int i = 0; i < riverDisplay.Count(); i++)
            {
                myBox[i].Image = returnImage(riverDisplay[i], out value);
                //lblNumOfCards1.Text = value;
            }
        }


        /// <summary>
        /// Returns the equivalent image stored in resources and sends it to the game
        /// </summary>
        /// <returns></returns>
        public Image returnImage(Card card, out String value)
        {
            value = "";
            if ((int)card.getCardRank() == 2)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    return Properties.Resources.Two_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    return Properties.Resources.Two_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    return Properties.Resources.Two_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    return Properties.Resources.Two_Spades;
                }

            }
            else if ((int)card.getCardRank() == 3)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    return Properties.Resources.Three_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    return Properties.Resources.Three_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    return Properties.Resources.Three_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    return Properties.Resources.Three_Spades;
                }
            }
            else if ((int)card.getCardRank() == 4)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    return Properties.Resources.Four_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    return Properties.Resources.Four_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    return Properties.Resources.Four_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    return Properties.Resources.Four_Spades;
                }
            }
            else if ((int)card.getCardRank() == 5)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    return Properties.Resources.Five_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    return Properties.Resources.Five_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    return Properties.Resources.Five_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    return Properties.Resources.Five_Spades;
                }
            }
            else if ((int)card.getCardRank() == 6)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    value = "Six Clubs";
                    return Properties.Resources.Six_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    value = "Six Diamonds";
                    return Properties.Resources.Six_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    value = "Six Hearts";
                    return Properties.Resources.Six_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    value = "Six Spades";
                    return Properties.Resources.Six_Spades;
                }
            }
            else if ((int)card.getCardRank() == 7)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    value = "Seven Clubs";
                    return Properties.Resources.Seven_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    value = "Seven Diamonds";
                    return Properties.Resources.Seven_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    value = "Seven Hearts";
                    return Properties.Resources.Seven_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    value = "Seven Spades";
                    return Properties.Resources.Seven_Spades;
                }
            }
            else if ((int)card.getCardRank() == 6)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    value = "Eight Clubs";
                    return Properties.Resources.Eight_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    value = "Eight Diamonds";
                    return Properties.Resources.Eight_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    value = "Eight Hearts";
                    return Properties.Resources.Eight_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    value = "Eight Spades";
                    return Properties.Resources.Eight_Spades;
                }
            }
            else if ((int)card.getCardRank() == 9)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    value = "Nine Clubs";
                    return Properties.Resources.Nine_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    value = "Nine Diamonds";
                    return Properties.Resources.Nine_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    value = "Nine Hearts";
                    return Properties.Resources.Nine_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    value = "Nine Spades";
                    return Properties.Resources.Nine_Spades;
                }
            }
            else if ((int)card.getCardRank() == 10)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    value = "Ten Clubs";
                    return Properties.Resources.Ten_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    value = "Ten Diamonds";
                    return Properties.Resources.Ten_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    value = "Ten Hearts";
                    return Properties.Resources.Ten_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    value = "Ten Spades";
                    return Properties.Resources.Ten_Spades;
                }
            }
            else if ((int)card.getCardRank() == 11)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    value = "Jack Clubs";
                    return Properties.Resources.Jack_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    value = "Jack Diamonds";
                    return Properties.Resources.Jack_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    value = "Jack Hearts";
                    return Properties.Resources.Jack_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    value = "Jack Spades";
                    return Properties.Resources.Jack_Spades;
                }
            }
            else if ((int)card.getCardRank() == 12)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    value = "Queen Clubs";
                    return Properties.Resources.Queen_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    value = "Queen Diamonds";
                    return Properties.Resources.Queen_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    value = "Queen Hearts";
                    return Properties.Resources.Queen_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    value = "Queen Spades";
                    return Properties.Resources.Queen_Spades;
                }
            }
            else if ((int)card.getCardRank() == 13)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    value = "King Clubs";
                    return Properties.Resources.King_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    value = "King Diamonds";
                    return Properties.Resources.King_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    value = "King Hearts";
                    return Properties.Resources.King_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    value = "King Spades";
                    return Properties.Resources.King_Spades;
                }
            }
            else if ((int)card.getCardRank() == 14)
            {
                if ((int)card.getCardSuit() == 0)
                { //Clubs
                    value = "Ace Clubs";
                    return Properties.Resources.Ace_Clubs;
                }
                else if ((int)card.getCardSuit() == 1)
                { //Diamond
                    value = "Ace Diamonds";
                    return Properties.Resources.Ace_Diamonds;
                }
                else if ((int)card.getCardSuit() == 2)
                { //Hearts
                    value = "Ace Hearts";
                    return Properties.Resources.Ace_Hearts;
                }
                else if ((int)card.getCardSuit() == 3)
                { //Spades
                    value = "Ace Spades";
                    return Properties.Resources.Ace_Spades;
                }
            }

            return null;
        }
        #endregion 
        #region Additional Requirements 
        /// <summary>
        /// Determines if the defending player has a card to transfer durak
        /// </summary>
        /// <param name="player"></param>
        /// <param name="gameRiver"></param>
        /// <returns></returns>
        private bool determineDurak(Player player, River gameRiver)
        {
            Suit playerSuit;
            Suit riverSuit;
            int ableToPlay = 0;

            //Will return the attacking card(which is the last card in the river
            Card card = new Card(gameRiver.getCard(gameRiver.length()-1));

            //Determine the suit of the last card
            riverSuit = card.getCardSuit();

            //determine if the player has a card of the same suit to play
            for (int handCounter = 0; handCounter < player.getHand().length(); handCounter++)
            {
                //Determine the suit of the current card
                playerSuit = player.getHand().getCard(handCounter).getCardSuit();

                //If the current card is the same suit, this means it is playable, increment counter
                if (playerSuit == riverSuit)
                {
                    ableToPlay++;
                }
            }

            //If the player does have a card of the same suit 
            if(ableToPlay >= 2)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Transfers the Durak to the next user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            playerTwo.getHand().addCards(gameRiver.getAll());

            //Set the player that is now attacking
            playerOne.setIsAttacking(true);
            playerTwo.setIsDefending(true);
        }

        /// <summary>
        /// Will output the game log to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowLog_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Will clear existing data in the log file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            gameLog.clearLogFile();
        }

        #endregion

        //Accidental Clicks
        private void pnlPlayerTwo_Paint(object sender, PaintEventArgs e) { }
        private void pnlTable1_Paint(object sender, PaintEventArgs e) { }
        private void pnlPlayer2_Paint(object sender, PaintEventArgs e) { }

    }
}
