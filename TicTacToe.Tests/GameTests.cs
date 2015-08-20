using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Game;

namespace TicTacToe.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestGameHasStarted()
        {
            

            throw new NotImplementedException();

            //Game3x3 game = new Game3x3()
        }

        [TestMethod]
        public void TestDisplayBoard()
        {
            string expected = string.Format("---{0}---{0}---{0}", Environment.NewLine);

            GameState state = new GameState();
            ConsoleGameDrawer drawer = new ConsoleGameDrawer();

            Game3x3 game = new Game3x3(state, drawer, null, null);
        }

        [TestMethod]
        public void TestBoardUpdates()
        {
            throw new NotImplementedException();
        }
    }
}
