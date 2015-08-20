using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Game;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Super-Awesome TicTacToe!!");
            Console.WriteLine();
            Console.Write("Any key to start");
            Console.ReadKey();

            // Create these objects and inject them into the game object, such
            // that the game has no idea about where it's drawing to, or what kind of players
            // are playing (Human / Computer etc)
            GenericGameState gameState = new GenericGameState();
            ConsoleGameDrawer drawer = new ConsoleGameDrawer();
            ComputerPlayer player1 = new ComputerPlayer("Jim", SpaceState.X);
            ComputerPlayer player2 = new ComputerPlayer("Susan", SpaceState.O);

            Game3x3 game = new Game3x3(gameState, drawer, player1, player2);

            RunGame(game);
        }

        static void RunGame(Game3x3 game)
        {
            Console.WriteLine();

            game.DrawBoardToOutput();
            Console.WriteLine("{0} goes first!", game.CurrentPlayer.PlayerName);

            while (!game.HasFinished())
            {
                System.Threading.Thread.Sleep(1000);
                game.MakeNextMove();
                game.DrawBoardToOutput();
                Console.WriteLine();

                if (game.WinDetected())
                    Console.WriteLine("{0}{1} has won the game!", Environment.NewLine, game.WinningPlayer.PlayerName);
                else if (game.HasFinished())
                    Console.WriteLine("Game finished. No winner!");
                else
                    Console.WriteLine("{0} plays next", game.CurrentPlayer.PlayerName);
            }
            

            Console.WriteLine("{0}Play again? y/n", Environment.NewLine);
            char key = Console.ReadKey().KeyChar;
            if (key == 'y' || key == 'Y')
            {
                game.ResetGame();
                RunGame(game);
            }
        }
    }
}
