using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Game;

namespace TicTacToe.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void TestGetNextMove()
        {
            GameState state = new GameState();
            ComputerPlayer player1 = new ComputerPlayer("Jim", SquareState.X);
            ComputerPlayer player2 = new ComputerPlayer("Denise", SquareState.X);

            Game3x3 game = new Game3x3(state, null, player1, player2);
            Space s = player1.NextMove(game);

            Assert.IsNotNull(s, "Should have returned an actual space");
        }

        [TestMethod]
        public void TestNextMoveGameFinished()
        {
            GameState state = new GameState();
            ComputerPlayer player1 = new ComputerPlayer("Jim", SquareState.X);
            ComputerPlayer player2 = new ComputerPlayer("Denise", SquareState.X);

            Game3x3 game = new Game3x3(state, null, player1, player2);
            finishGame(game);

            Assert.IsNull(player1.NextMove(game), "Should return null as there are no spaces");
        }

        private void finishGame(GenericTicTacToeGame game)
        {
            foreach(Space s in game.Spaces) {
                s.State = SquareState.X;
            }
        }
    }
}
