using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    internal class Menu
    {
        public int display_main_menu()
        {
            Console.WriteLine("welcome to x-o Game :");
            Console.WriteLine("1-start Game:");
            Console.WriteLine("2-Quit Game:");

            while (true)
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1 || choice == 2)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("invalid choice , please enter only (1 or 2)");
                }
               
            }
        }

        public int display_Endgame_menu()
        {
            Console.WriteLine("Enter your choice (1 or 2)");
            Console.WriteLine("1-Restart Game:");
            Console.WriteLine("2-Quit Game:");

            while (true)
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1 || choice == 2)
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("invalid choice , please enter only (1 or 2)");
                }

            }
        }
    }
}
