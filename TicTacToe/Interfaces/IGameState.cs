using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Interfaces
{
    public interface IGameState
    {
        public bool HasStarted();

        public bool HasFinished();
    }
}
