using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Game
{
    public class Game 
    {
        readonly IGameState _gameState;
        readonly IGameDrawer _gameDrawer;
        readonly IPlayer _player1;
        readonly IPlayer _player2;

        public Game(IGameState gameState, IGameDrawer gameDrawer, IPlayer player1, IPlayer player2)
        {
            _gameState = gameState;
            _gameDrawer = gameDrawer;
            _player1 = player1;
            _player2 = player2;
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
    }
}
