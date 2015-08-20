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
        }

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
            throw new NotImplementedException();
        }
    }
}
