using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Game
{
    public class Game3x3 : GenericTicTacToeGame
    {
        private const int WIDTH = 3;
        private const int HEIGHT = 3;

        readonly IGameState _gameState;
        readonly IGameDrawer _gameDrawer;
        readonly IPlayer _player1;
        readonly IPlayer _player2;
        private IPlayer _currentPlayer;

        /// <summary>
        /// This constructor passes up the width and height to the abstract class constructor. Let it deal with
        /// the size. We just want to get the required bits that we need to run the game
        /// </summary>
        public Game3x3(IGameState gameState, IGameDrawer gameDrawer, IPlayer player1, IPlayer player2) : base(WIDTH, HEIGHT)
        {
            _gameState = gameState;
            _gameDrawer = gameDrawer;
            _player1 = player1;
            _player2 = player2;
            _currentPlayer = player1;

            InitializeBoard();
        }

        #region Properties

        // Here we make an assumption that if no current player is defined, then the first
        // player is the current player
        public IPlayer CurrentPlayer
        {
            get
            {
                if (_currentPlayer == null)
                    _currentPlayer = Player1;
                return _currentPlayer;
            }
            set
            {
                _currentPlayer = value;
            }
        }
        public IPlayer WinningPlayer { get; set; }

        public IGameState GameState {
            get
            {
                return _gameState;
            }
        }

        public IGameDrawer GameDrawer
        {
            get
            {
                return _gameDrawer;
            }
        }

        public IPlayer Player1
        {
            get
            {
                return _player1;
            }
        }

        public IPlayer Player2
        {
            get
            {
                return _player2;
            }
        }

        public override List<Space> Spaces
        {
            get {
                return _spaces;
            }
        }

        #endregion

        /// <summary>
        /// Create a space for each item in our nxn grid
        /// </summary>
        public override void InitializeBoard()
        {
            for (int i = 0; i < BoardWidth; i++)
            {
                for (int j = 0; j < BoardHeight; j++)
                {
                    Spaces.Add(new Space(i, j));
                }
            }
        }

        // Has this space already been played?
        public override bool SpaceOccupied(Space space)
        {
            return space.State != SpaceState.FREE;
        }

        // Space at this coordinate. Note that we have hidden the Point implmenetation which we
        // are actually using to store the locations in the Space class. The game doesn't need to
        // know that we are using Points
        public override Space SpaceAt(int x, int y) 
        {
            return Spaces.SingleOrDefault(s => s.Location.X == x && s.Location.Y == y);
        }

        // A list of all unplayed spaces
        public override List<Space> GetAvailableSpaces()
        {
            return (from s in Spaces where s.State == SpaceState.FREE select s).ToList();
        }

        // Gets the next move for the current player, checks to see if the game has been won,
        // if so, sets the Winning player, otherwise sets the Current Player to to be the next player.
        // This is only a 2-player version, but in other implementations of GenericTicTacToeGame, there 
        // is nothing stopping having more than 2 players
        public override void MakeNextMove()
        {
            Space space = CurrentPlayer.NextMove(this);
            if (space != null)
            {
                space.State = CurrentPlayer.PlayerToken;
            }
            if (WinDetected())
                WinningPlayer = CurrentPlayer;
            else
                CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
        }

        // Is the game in a Won state?
        public override bool WinDetected()
        {
            bool result = false;

            // Check columns
            for (int i = 0; i < BoardWidth; i++)
            {
                Space col0 = SpaceAt(i, 0);
                if (col0.State != SpaceState.FREE)
                {
                    result = SpaceAt(i, 1).State == col0.State && SpaceAt(i, 2).State == col0.State;
                }
                if (result)
                    return true;
            }
            // Check rows
            for (int j = 0; j < BoardHeight; j++)
            {
                Space row0 = SpaceAt(0, j);
                if (row0.State != SpaceState.FREE)
                {
                    result = SpaceAt(1, j).State == row0.State && SpaceAt(2, j).State == row0.State;
                }
                if (result)
                    return true;
            }
            // Check Diagonals
            Space d0 = SpaceAt(0, 0);
            if(d0.State != SpaceState.FREE) {
                result = d0.State == SpaceAt(1, 1).State && d0.State == SpaceAt(2, 2).State;
            }
            d0 = SpaceAt(2, 0);
            if (d0.State != SpaceState.FREE)
            {
                result = d0.State == SpaceAt(1, 1).State && d0.State == SpaceAt(0, 2).State;
            }
            return result;
        }

        // Has at least one move been made?
        public bool HasStarted()
        {
            return GameState.HasStarted(this);
        }

        // Have all possible moves been made? Or has someone won?
        public bool HasFinished()
        {
            return GameState.HasFinished(this) || WinDetected();
        }

        // Reset to initial conditions
        public override void ResetGame()
        {
            foreach (Space s in Spaces)
            {
                s.State = SpaceState.FREE;
            }
            WinningPlayer = null;
            CurrentPlayer = Player1;
        }

        #region Drawing methods

        // Draw our board to whatever device our GameDrawer object wants to send it to
        public void DrawBoardToOutput()
        {
            GameDrawer.DrawBoardToOutput(this);
        }

        #endregion
    }
}
