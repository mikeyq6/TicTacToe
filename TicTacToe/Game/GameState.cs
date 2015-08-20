using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Game
{
    public class GameState : IGameState
    {

        public bool HasStarted(GenericTicTacToeGame game)
        {
            return (from s in game.Spaces where !s.HasBeenPlayed() select s).FirstOrDefault() != default(Space);
        }

        public bool HasFinished(GenericTicTacToeGame game)
        {
            return (from s in game.Spaces where !s.HasBeenPlayed() select s).FirstOrDefault() == default(Space);
        }
    }
}
