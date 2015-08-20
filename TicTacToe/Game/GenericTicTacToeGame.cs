using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game
{
    /// <summary>
    /// A nxn generic abstract class for TicTacToe. The required example only requires 
    /// 3x3, but there are versions of TTT which use 4x4 or more, so this is a good way
    /// of ensuring that if this comes up in future, then we are prepared
    /// </summary>
    public abstract class GenericTicTacToeGame
    {
        protected readonly int _boardWidth;
        protected readonly int _boardHeight;
        protected List<Space> _spaces;

        /// <summary>
        /// Width and height are required for any game of this type, so is sensible to define them
        /// in the abstract class. Also a game board of Spaces is also a given.
        /// </summary>
        protected GenericTicTacToeGame(int width, int height)
        {
            _boardWidth = width;
            _boardHeight = height;
            _spaces = new List<Space>();
        }

        public int BoardWidth
        {
            get
            {
                return _boardWidth;
            }
        }

        public int BoardHeight
        {
            get
            {
                return _boardWidth;
            }
        }
        public abstract List<Space> Spaces { get; }

        public abstract void InitializeBoard();

        public abstract bool SpaceOccupied(Space square);

        public abstract Space SpaceAt(int x, int y);

        public abstract List<Space> GetAvailableSpaces();

        public abstract void MakeNextMove();

        public abstract bool WinDetected();

        public abstract void ResetGame();
    }
}
