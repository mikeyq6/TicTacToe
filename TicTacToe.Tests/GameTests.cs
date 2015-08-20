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
            GameState state = new GameState();
            ConsoleGameDrawer drawer = new ConsoleGameDrawer();

            Game3x3 game = new Game3x3(state, drawer, null, null);
            Space s = game.SpaceAt(2, 0);

            Assert.IsFalse(game.HasStarted());
            s.State = SquareState.O;
            Assert.IsTrue(game.HasStarted());
        }

        [TestMethod]
        public void TestGameHasFinished()
        {
            GameState state = new GameState();
            ConsoleGameDrawer drawer = new ConsoleGameDrawer();

            Game3x3 game = new Game3x3(state, drawer, null, null);

            Assert.IsFalse(game.HasFinished());
            foreach(Space s in game.Spaces) {
                s.State = SquareState.X;
            }

            Assert.IsTrue(game.HasFinished());
        }

        [TestMethod]
        public void TestDisplayBoard()
        {
            string expected = string.Format("---{0}---{0}---{0}", Environment.NewLine);

            GameState state = new GameState();
            ConsoleGameDrawer drawer = new ConsoleGameDrawer();

            Game3x3 game = new Game3x3(state, drawer, null, null);

            Assert.AreEqual(expected, game.GameDrawer.DrawBoardToString(game), "Expected board is different to actual");
        }

        [TestMethod]
        public void TestBoardUpdates()
        {
            string expected = string.Format("--X{0}-O-{0}X--{0}", Environment.NewLine);

            GameState state = new GameState();
            ConsoleGameDrawer drawer = new ConsoleGameDrawer();

            Game3x3 game = new Game3x3(state, drawer, null, null);

            Assert.AreNotEqual(expected, game.GameDrawer.DrawBoardToString(game), "Expected board is the same as actual, shouldn't be");
            game.SpaceAt(2, 0).State = SquareState.X;
            game.SpaceAt(1, 1).State = SquareState.O;
            game.SpaceAt(0, 2).State = SquareState.X;
            Assert.AreEqual(expected, game.GameDrawer.DrawBoardToString(game), "Expected board is different to actual");
        }

        [TestMethod]
        public void TestWinDetection()
        {
            string expected = string.Format("--X{0}-OX{0}O-X{0}", Environment.NewLine);

            GameState state = new GameState();
            ConsoleGameDrawer drawer = new ConsoleGameDrawer();

            Game3x3 game = new Game3x3(state, drawer, null, null);

            Assert.AreNotEqual(expected, game.GameDrawer.DrawBoardToString(game), "Expected board is the same as actual, shouldn't be");
            game.SpaceAt(2, 0).State = SquareState.X;
            game.SpaceAt(1, 1).State = SquareState.O;
            game.SpaceAt(0, 2).State = SquareState.O;
            game.SpaceAt(2, 1).State = SquareState.X;
            Assert.IsFalse(game.WinDetected(), "Should have not detected a winning row");
            game.SpaceAt(2, 2).State = SquareState.X;
            Assert.IsTrue(game.WinDetected(), "Should have detected the winning row");
        }
    }
}
