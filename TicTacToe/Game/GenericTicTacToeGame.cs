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
        protected List<Point> _spaces;


        protected GenericTicTacToeGame(int width, int height)
        {
            _boardWidth = width;
            _boardHeight = height;
            _spaces = new List<Point>();
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
        public abstract List<Point> Spaces { get; }

        public abstract void InitializeBoard();

        public abstract bool SpaceOccupied(Point point);

        public abstract List<Point> GetAvailableSpaces();
    }
}
