using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TicTacToe.ViewModels;

namespace TicTacToe
{
    /// <summary>
    /// defining winning logic class to check for game tie, game win player 1, 2, and the win directions.
    /// </summary>
    public class WinningLogic
    {
        /// <summary>
        /// Defining the GameViewModel in this class so it can be used throughout the rest of the class
        /// </summary>
        /// <param name="gvm"></param>
        public WinningLogic(GameViewModel gvm)
        {
            this.gvm = gvm;
        }
        private GameViewModel gvm;
        /// <summary>
        /// Called if the game is a tie
        /// </summary>
        public void GameEndTie()
        {
            //Getting a local reference to the view model
            if (gvm == null)
            {
                return;
            }
            //Increments ties
            gvm.Ties++;
            //Displays in game status that it is a tie
            gvm.GameStatus = "It's a tie!";
        }
        /// <summary>
        /// Called if player 1 (X) is the winner
        /// </summary>
        public void GameEndPlayer1Win(Border[] borderArray)
        {
            //Getting a local reference to the view model
            if (gvm == null)
            {
                return;
            }
            //Goes through and disables all squares so after a winning move is completed the game can no longer be played
            foreach (Border border in borderArray)
            {
                Image img = (Image)border.Child;
                img.IsEnabled = false;
            }
            //Increments player 1 win
            gvm.WinsPlayer1++;
            //Displays in the status section of the game board that player 1 wins and explains that the winning move was highlighted
            gvm.GameStatus = "Player 1 wins!\nThe winning move has\nbeen highlighted blue!\nGood job!";
            //Resets the game grid

        }
        /// <summary>
        /// Called if player 2 (O) is the winner
        /// </summary>
        public void GameEndPlayer2Win(Border[] borderArray)
        {
            //Getting a local reference to the view model
            if (gvm == null)
            {
                return;
            }
            //Goes through and disables all squares so after a winning move is completed the game can no longer be played
            foreach (Border border in borderArray)
            {
                Image img = (Image)border.Child;
                img.IsEnabled = false;
            }
            //increments player 2 win
            gvm.WinsPlayer2++;
            //Displays in the status section of the game board that player 2 wins and explains that the winning move was highlighted
            gvm.GameStatus = "Player 2 wins!\nThe winning move has\nbeen highlighted blue!\nGood job!";

        }
        /// <summary>
        /// Method that checks to see if there is in fact a match in the direction. returns the direction of the match if there is one
        /// </summary>
        /// <param name="initialRow"></param>
        /// <param name="initialCol"></param>
        /// <param name="desiredPlayer"></param>
        /// <returns></returns>
        public WinDirections findMatch(int initialRow, int initialCol, int desiredPlayer)
        {
            //check DiagonalUpLeft
            if (initialCol > 0 && initialRow > 0 && gvm.GameBoard[initialRow - 1, initialCol - 1] == desiredPlayer)
            {
                return WinDirections.DiagonalUpLeft;
            }
            //Check DiagonalUpRight
            else if (initialCol < 2 && initialRow > 0 && gvm.GameBoard[initialRow - 1, initialCol + 1] == desiredPlayer)
            {
                return WinDirections.DiagonalUpRight;
            }
            //Check DiagonalDownLeft
            else if (initialCol > 0 && initialRow < 2 && gvm.GameBoard[initialRow + 1, initialCol - 1] == desiredPlayer)
            {
                return WinDirections.DiagonalDownLeft;
            }
            //Check diagonal DownRight
            else if (initialCol < 2 && initialRow < 2 && gvm.GameBoard[initialRow + 1, initialCol + 1] == desiredPlayer)
            {
                return WinDirections.DiagonalDownRight;
            }
            //check left
            else if (initialCol > 0 && (initialRow >= 0 && initialRow <= 2) && gvm.GameBoard[initialRow, initialCol - 1] == desiredPlayer)
            {
                return WinDirections.Left;
            }
            //Check right
            else if (initialCol < 2 && (initialRow >= 0 && initialRow <= 2) && gvm.GameBoard[initialRow, initialCol + 1] == desiredPlayer)
            {
                return WinDirections.Right;
            }
            //Check up
            else if (initialRow > 0 && (initialCol >= 0 && initialCol <= 2) && gvm.GameBoard[initialRow - 1, initialCol] == desiredPlayer)
            {
                return WinDirections.Up;
            }
            //Check down
            else if (initialRow < 2 && (initialCol >= 0 && initialCol <= 2) && gvm.GameBoard[initialRow + 1, initialCol] == desiredPlayer)
            {
                return WinDirections.Down;
            }
            //Else do nothing
            else
            {
                return WinDirections.None;
            }
        }

    }
}
