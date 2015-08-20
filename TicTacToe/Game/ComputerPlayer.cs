using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Game
{
    /// <summary>
    /// In this application, we have only one kind of player, a computer player. But we could just as easily added
    /// a Human player implementation. The game doesn't care. All it wants is a player.
    /// </summary>
    public class ComputerPlayer : IPlayer
    {
        public ComputerPlayer(string playerName, SpaceState token)
        {
            PlayerName = playerName;
            PlayerToken = token;
        }

        #region Properties

        public string PlayerName { get; set; }

        public SpaceState PlayerToken { get; set; }

        #endregion

        public Space NextMove(GenericTicTacToeGame game)
        {
            Random r = new Random();

            // Select a random square
            List<Space> available = game.GetAvailableSpaces();

            if(available.Count == 0) // None left
                return null;
            else // Get a random space from the remaining set
                return available.ElementAt(r.Next(0, available.Count-1));
        }
    }
}
