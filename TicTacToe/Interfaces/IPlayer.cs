using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Interfaces
{
    /// <summary>
    /// Interface to be passed into a game as a player
    /// </summary>
    public interface IPlayer
    {
        string PlayerName { get; set; }

        Point NextMove(IGameState gameState);
    }
}
