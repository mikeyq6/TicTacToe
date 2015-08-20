﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Interfaces
{
    public interface IGameDrawer
    {
        string DrawBoard(IGameState gameState);
    }
}
