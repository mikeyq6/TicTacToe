using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Game
{
    /// <summary>
    /// Since this class is generic to the kind of game we pass in, the Interface is a little
    /// superfluous, however were we to add a new kind of game that has slightly different rules for
    /// winning, then this might be an important use-case for creating a new implementation of IGameState
    /// </summary>
    public class GenericGameState : IGameState
    {
        public bool HasStarted(GenericTicTacToeGame game)
        {
            return (from s in game.Spaces where s.HasBeenPlayed() select s).FirstOrDefault() != default(Space);
        }

        public bool HasFinished(GenericTicTacToeGame game)
        {
            return (from s in game.Spaces where !s.HasBeenPlayed() select s).FirstOrDefault() == default(Space);
        }
    }
}
