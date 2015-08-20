using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Game
{
    /// <summary>
    /// A specific implementation of the IGameDrawer that is used to draw to the Console. We could put this
    /// interface to use for different kinds of output (file, webpage, etc). 
    /// </summary>
    public class ConsoleGameDrawer : IGameDrawer
    {

        public string DrawBoardToString(GenericTicTacToeGame game)
        {
            // Since potentially we could be dealing with a huge number of squares (there is no
            // limit on board size), then use a string builder to save memory
            StringBuilder str_sp = new StringBuilder();

            for (int i = 0; i < game.BoardWidth; i++)
            {
                for (int j = 0; j < game.BoardHeight; j++)
                {
                    Space space = game.SpaceAt(i, j);

                    switch(space.State) {
                        case SpaceState.O:
                            str_sp.Append("O"); break;
                        case SpaceState.X:
                            str_sp.Append("X"); break;
                        default:
                            str_sp.Append("-"); break;
                    }
                }
                str_sp.Append(Environment.NewLine);
            }

            return str_sp.ToString();
        }

        public void DrawBoardToOutput(GenericTicTacToeGame game)
        {
            Console.Write(DrawBoardToString(game));
        }
    }
}
