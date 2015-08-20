using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Interfaces;

namespace TicTacToe.Game
{
    public class ConsoleGameDrawer : IGameDrawer
    {

        public string DrawBoardToString(GenericTicTacToeGame game)
        {
            StringBuilder str_sp = new StringBuilder();

            for (int i = 0; i < game.BoardWidth; i++)
            {

                for (int j = 0; j < game.BoardHeight; j++)
                {
                    Space space = game.SpaceAt(i, j);

                    switch(space.State) {
                        case SquareState.O:
                            str_sp.Append("O"); break;
                        case SquareState.X:
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
