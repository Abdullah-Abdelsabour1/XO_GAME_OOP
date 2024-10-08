using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    internal class Game
    {
        private List<Player> players  = new List<Player> {new Player() , new Player()};

        private Board board = new Board();

        private Menu menu = new Menu();

        private int currentPlayerIndex = 0;

        public void startGame()
        {
            int choice = menu.display_main_menu();
            if (choice == 1)
            {
                setupPlayers();
                playGame();
            }
            else
              QuitGame();
        }
        public void setupPlayers()
        {
            for (int i = 0; i < players.Count; i++) 
            {
                Console.WriteLine($"player ({i + 1}) , Enter your details: ");
                players[i].choose_name();
                players[i].choose_symbol();
                Console.WriteLine("======================");
            }
        }
        public void playGame()
        {
            while (true) 
            {
                playTurn();
                if (checkdraw() || checkWin())
                {
                    if (checkWin())
                    {
                        Console.WriteLine("congratulation you win => " + players[currentPlayerIndex - 1].printName());
                    }
                    else
                    {
                        Console.WriteLine("Game Over !");   
                    }
                    board.display();
                    int choice = menu.display_Endgame_menu();
                    if (choice == 1)
                    {
                        restartGame();
                    }
                    else
                    {
                        QuitGame();
                        break;
                    }
                }
            }
        }
        public void playTurn()
        {
            Player player = players[currentPlayerIndex];
            board.display();
            Console.WriteLine($"{player.printName()}'s turn , his symbol: {player.printSymbol()}");
            while (true)
            {
                Console.WriteLine("choose cell (1-9) : ");
                bool result = false;
                try
                {
                    int cellChoice = Convert.ToInt32(Console.ReadLine());
                    char symbol = player.printSymbol();
                    result = board.update(cellChoice, symbol);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error , please enter number between (1-9)");
                }

                if (result)
                    break;
            }
            switchPlayer();
        }
        public void switchPlayer()
        {
            this.currentPlayerIndex = 1 - this.currentPlayerIndex;   
        }
        public void restartGame()
        {
            board.reset();
            currentPlayerIndex = 0;
            playGame();
        }
        public bool checkWin()
        {
            int[,] WinCondtion = new int[,]
            {
                {0, 1, 2}, {3, 4, 5}, {6, 7, 8},  // Rows
                {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, // Columns
                {0, 4, 8}, {2, 4, 6}            // Diagonals
            };
            bool win = false ;
            for (int i = 0; i < WinCondtion.GetLength(0); i++)
            {
                int e1 = WinCondtion[i,0];
                int e2 = WinCondtion[i, 1];
                int e3 = WinCondtion[i, 2];
                if (board.mybord[e1] == board.mybord[e2] && board.mybord[e1] == board.mybord[e3] && board.mybord[e2] == board.mybord[e3])
                {
                    win = true;
                    break;
                }
                if (win)
                    break;
            }
            return win;
        }
        public bool checkdraw()
        {
            bool draw = true;
            for (int i = 0; i < board.mybord.Length ; i++)
            {
                if (!char.IsLetter(board.mybord[i]))
                {
                     draw = false;
                     break;
                }
            }
            return draw;
        }
        public void QuitGame()
        {
            Console.WriteLine("thank you");
        }
    }

}
