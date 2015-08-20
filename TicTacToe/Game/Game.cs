using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Game
{
    public class Game : GenericTicTacToeGame
    {
        readonly IGameState _gameState;
        readonly IGameDrawer _gameDrawer;
        readonly IPlayer _player1;
        readonly IPlayer _player2;

        public Game(int width, int height, IGameState gameState, IGameDrawer gameDrawer, IPlayer player1, IPlayer player2) : base(width, height)
        {
            _gameState = gameState;
            _gameDrawer = gameDrawer;
            _player1 = player1;
            _player2 = player2;
        }

        #region Properties

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

        public override List<Point> Spaces
        {
            get {
                return _spaces;
            }
        }

        #endregion


        public override void InitializeBoard()
        {
            for (int i = 0; i < BoardWidth; i++)
            {
                for (int j = 0; j < BoardHeight; j++)
                {
                    Spaces.Add(new Point(i, j));
                }
            }
        }

        public override bool SpaceOccupied(System.Drawing.Point point)
        {
            throw new NotImplementedException();
        }

        public override List<System.Drawing.Point> GetAvailableSpaces()
        {
            throw new NotImplementedException();
        }
    }
}
