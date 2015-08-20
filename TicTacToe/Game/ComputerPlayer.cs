using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Game
{
    class ComputerPlayer : IPlayer
    {
        public ComputerPlayer(string playerName)
        {
            PlayerName = playerName;
        }

        public System.Drawing.Point NextMove(IGameState gameState)
        {
            throw new NotImplementedException();
        }

        public string PlayerName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
