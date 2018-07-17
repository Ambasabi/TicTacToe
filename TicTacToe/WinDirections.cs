using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// enum to hold winning directions
    /// </summary>
    public enum WinDirections
    {
        /// <summary>
        /// left win direction
        /// </summary>
        Left,
        /// <summary>
        /// right win direction
        /// </summary>
        Right,
        /// <summary>
        /// down win direction
        /// </summary>
        Down,
        /// <summary>
        /// up win direction
        /// </summary>
        Up,
        /// <summary>
        /// diagonal up left position
        /// </summary>
        DiagonalUpLeft,
        /// <summary>
        /// diagonal up right position
        /// </summary>
        DiagonalUpRight,
        /// <summary>
        /// Diagonal down left position
        /// </summary>
        DiagonalDownLeft,
        /// <summary>
        /// diagonal down right position
        /// </summary>
        DiagonalDownRight,
        /// <summary>
        /// No win direction
        /// </summary>
        None
    }
}
