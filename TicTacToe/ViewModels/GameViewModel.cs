using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        /// <summary>
        /// Constructor intializing player 1 to go first
        /// </summary>
        public GameViewModel()
        {
            this.PlayerTurn = 1;
        }
        /// <summary>
        /// the value. private so no one can access it directly
        /// </summary>
        private int winsPlayer1;
        /// <summary>
        /// Public int property that keeps track of how many times player 1 won. has accessor and modifier (get and set) to read and update the value
        /// </summary>
        public int WinsPlayer1
        {
            get
            {
                return winsPlayer1;
            } 
            set
            {
                winsPlayer1 = value;
                OnPropertyChanged("WinsPlayer1");
            }
        }//End Public int WinsPlayer1
        /// <summary>
        /// the value. private so no one can access it directly
        /// </summary>
        private int winsPlayer2;
        /// <summary>
        /// Public int property that keeps track of how many times player 2 won. has accessor and modifier (get and set) to read and update the value
        /// </summary>
        public int WinsPlayer2
        {
            get
            {
                return winsPlayer2;
            }
            set
            {
                winsPlayer2 = value;
                OnPropertyChanged("WinsPlayer2");
            }
        }//End Public Int WinsPlayer2
        /// <summary>
        /// the value. private so no one can access it directly
        /// </summary>
        private int ties;
        /// <summary>
        /// Public int property that keep track of how many times the game was tied. has accessor and modifier (get and set) to read and update the value
        /// </summary>
        public int Ties
        {
            get
            {
                return ties;
            }
            set
            {
                ties = value;
                OnPropertyChanged("Ties");
            }
        }//End public int ties
        /// <summary>
        /// The value. private so no one can access it directly.
        /// </summary>
        private string gameStatus;
        /// <summary>
        /// dynamically updates the status of the game i.e. whose turn it is, if player 1 won, player 2 won, game tied.
        /// </summary>
        public string GameStatus
        {
            get
            {
                return gameStatus;
            }
            set
            {
                gameStatus = value;
                OnPropertyChanged("GameStatus");
            }
        }
        /// <summary>
        /// the value. private so no one can access it directly.
        /// </summary>
        private int playerTurn;
        /// <summary>
        /// public int that keeps track of the player's turn. has accessor and modifier (get and set) to read and update the value
        /// </summary>
        public int PlayerTurn
        {
            get
            {
                return playerTurn;
            }
            set
            {
                playerTurn = value;
                OnPropertyChanged("PlayerTurn");
                this.GameStatus = string.Format("Player {0}'s turn", playerTurn);
            }
        }
        /// <summary>
        /// the value. private so no one can access it directly
        /// </summary>
        private int[,] gameBoard = new int[3,3];
        /// <summary>
        /// public int variable that initializes a new game board to a 3 dimensional array so the user can start playing the game
        /// </summary>
        public int[,] GameBoard
        {
            get
            {
                return gameBoard;
            }
            set
            {
                gameBoard = value;
                OnPropertyChanged("GameBoard");
            }
        }
    }
}
