using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game
{
    public abstract class GenericTicTacToeGame
    {
        protected readonly int _boardWidth;
        protected readonly int _boardHeight;
        protected List<Space> _spaces;


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
    }
}
