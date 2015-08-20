using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Game
{
    public sealed class Game3x3 : GenericTicTacToeGame
    {
        private const int WIDTH = 3;
        private const int HEIGHT = 3;

        readonly IGameState _gameState;
        readonly IGameDrawer _gameDrawer;
        readonly IPlayer _player1;
        readonly IPlayer _player2;
        private IPlayer _currentPlayer;

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
        /// Create a point for each square in the field
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

        public override bool SpaceOccupied(Space space)
        {
            throw new NotImplementedException();
        }

        public override Space SpaceAt(int x, int y) 
        {
            return Spaces.SingleOrDefault(s => s.Location.X == x && s.Location.Y == y);
        }

        public override List<Space> GetAvailableSpaces()
        {
            return (from s in Spaces where s.State == SquareState.FREE select s).ToList();
        }

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

        public override bool WinDetected()
        {
            bool result = false;

            // Check columns
            for (int i = 0; i < BoardWidth; i++)
            {
                Space col0 = SpaceAt(i, 0);
                if (col0.State != SquareState.FREE)
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
                if (row0.State != SquareState.FREE)
                {
                    result = SpaceAt(1, j).State == row0.State && SpaceAt(2, j).State == row0.State;
                }
                if (result)
                    return true;
            }
            // Check Diagonals
            Space d0 = SpaceAt(0, 0);
            if(d0.State != SquareState.FREE) {
                result = d0.State == SpaceAt(1, 1).State && d0.State == SpaceAt(2, 2).State;
            }
            d0 = SpaceAt(2, 0);
            if (d0.State != SquareState.FREE)
            {
                result = d0.State == SpaceAt(1, 1).State && d0.State == SpaceAt(0, 2).State;
            }
            return result;
        }

        public bool HasStarted()
        {
            return GameState.HasStarted(this);
        }

        public bool HasFinished()
        {
            return GameState.HasFinished(this) || WinDetected();
        }

        public override void ResetGame()
        {
            foreach (Space s in Spaces)
            {
                s.State = SquareState.FREE;
            }
            WinningPlayer = null;
            CurrentPlayer = Player1;
        }

        #region Drawing methods

        public void DrawBoardToOutput()
        {
            GameDrawer.DrawBoardToOutput(this);
        }

        #endregion
    }
}
