using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game
{
    /// <summary>
    /// Represents a space on our Tic Tac Toe board. Could have used a similar pattern to the player and
    /// state objects by using an interface, however I think in this case, there isn't much call for 
    /// different kinds of spaces, so makes sense to use a normal class.
    /// </summary>
    public class Space
    {
        private Point _location;
        private SpaceState _state;

        public Space(int x, int y)
        {
            _location = new Point(x, y);
            _state = SpaceState.FREE;
        }

        #region Properties

        public Point Location
        {
            get
            {
                return _location;
            }
        }

        public SpaceState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        #endregion

        public bool HasBeenPlayed()
        {
            return _state != SpaceState.FREE;
        }
    }

    /// <summary>
    /// Defined here in the Space class, since they are so closely related. Could also have defined
    /// it in a separate location which defines loads of enums, and there is a good case for that, especially
    /// in situations where there are a lot of them and used frequently, but since there is only one, can't
    /// hurt to define it here
    /// </summary>
    public enum SpaceState
    {
        FREE,
        X,
        O
    }
}
