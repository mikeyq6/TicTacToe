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

        public Space(Point location)
        {
            _location = location;
            _state = SquareState.FREE;
        }
    }

    public enum SquareState
    {
        FREE,
        X,
        O
    }
}
