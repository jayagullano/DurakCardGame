using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  OOP III Final Project 
 *  
 *  Completed by Deanna, Praveen, Gowshigan, Rolando
 *  Date Completed: April 17, 2020
 *  File: GameLog.cs
 *  
 *  Purpose: This file allows for the gamelog to be outputted.
 * 
 */

namespace Project_GUI
{
    class GameLog
    {
        public string fileName = "gamelog.txt";

        /// <summary>
        /// Creates the log and writes the date and time to the file
        /// </summary>
        /// <param name="logMessage"></param>
        public void log(String logMessage)
        {
            using (FileStream aFile = new FileStream(fileName, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(aFile))
            {
                sw.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                sw.Write("  : ");
                sw.WriteLine(logMessage);
            }
        }

        /// <summary>
        /// Method that takes in a string that writes the string to an output file
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            StreamWriter streamWriter = File.AppendText(fileName);
            streamWriter.WriteLine(message);
            streamWriter.Close();
        }

        /// <summary>
        /// Log the round 
        /// </summary>
        /// <param name="gameLog"></param>
        /// <param name="roundNumber"></param>
        /// <param name="playerOne"></param>
        /// <param name="playerTwo"></param>
        /// <param name="gameRiver"></param>
        public void LogRound(GameLog gameLog, int roundNumber, Player playerOne, ComputerAI playerTwo, River gameRiver)
        {
            gameLog.Log("\nROUND: " + roundNumber.ToString()
            + "\n\t" + playerOne.getHand().ToString(playerOne.getHand(), playerOne.getName())
            + "\n\n\t" + playerTwo.getHand().ToString(playerTwo.getHand(), playerTwo.getName())
            + gameRiver.ToString(gameRiver));
        }

        /// <summary>
        /// Clear the log file
        /// </summary>
        public void clearLogFile()
        {
            System.IO.File.WriteAllText(fileName, string.Empty);
        }

        /// <summary>
        /// Writes the winner name to the log file
        /// </summary>
        /// <param name="winnerName"></param>
        private void writeWinner(String winnerName)
        {
            using (FileStream aFile = new FileStream("GameLog.txt", FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(aFile))
            {
                sw.WriteLine(winnerName);
            }
        }
    }
}
