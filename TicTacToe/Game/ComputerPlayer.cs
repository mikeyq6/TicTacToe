using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Game
{
    public class ComputerPlayer : IPlayer
    {
        public ComputerPlayer(string playerName, SquareState token)
        {
            PlayerName = playerName;
            PlayerToken = token;

        }

        public Space NextMove(GenericTicTacToeGame game)
        {
            Random r = new Random();

            // Select a random square
            List<Space> available = game.GetAvailableSpaces();

            if(available.Count == 0)
                return null;
            else
                return available.ElementAt(r.Next(0, available.Count-1));
        }

        public string PlayerName { get; set; }


        public SquareState PlayerToken { get; set; }
    }
}
