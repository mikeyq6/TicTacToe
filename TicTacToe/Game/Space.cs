using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game
{
    public class Space
    {
        private Point _location;
        private SquareState _state;

        public Space(int x, int y)
        {
            _location = new Point(x, y);
            _state = SquareState.FREE;
        }

        #region Properties

        public Point Location
        {
            get
            {
                return _location;
            }
        }

        public SquareState State
        {
            get
            {
                return _state;
            }
        }

        #endregion

        public bool HasBeenPlayed()
        {
            return _state != SquareState.FREE;
        }
    }

    public enum SquareState
    {
        FREE,
        X,
        O
    }
}
