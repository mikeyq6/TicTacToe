﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game;

namespace TicTacToe.Interfaces
{
    /// <summary>
    /// Interface to be passed into a game as a player
    /// </summary>
    public interface IPlayer
    {
        string PlayerName { get; set; }
        SpaceState PlayerToken { get; set; }

        Space NextMove(GenericTicTacToeGame game);
    }
}
