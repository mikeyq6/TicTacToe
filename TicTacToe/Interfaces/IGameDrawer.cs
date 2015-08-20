using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game;

namespace TicTacToe.Interfaces
{
    public interface IGameDrawer
    {
        string DrawBoardToString(GenericTicTacToeGame game);

        void DrawBoardToOutput(GenericTicTacToeGame game);
    }
}
