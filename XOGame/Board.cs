using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace XOGame
{
    internal class Board
    {
        public char[] mybord = new char[9] ;
        public Board()
        {
            for (int i = 0; i < mybord.Length; i++)
            {
                mybord[i] = (char)('1' + i); //  '0' + i => convert number to ascicode then then return to char 
            }
        }
        public void display()
        {
            for (int i = 0; i < mybord.Length; i++)
            {
                Console.Write(mybord[i]);

                if ((i + 1) % 3 == 0)
                    Console.WriteLine(); // Start a new line after every third character.
                else
                    Console.Write(" | "); // Print separator between characters.
            }
        }
        public bool update(int choice , char symbol)
        {
            bool updated = false;
            if (choice <= mybord.Length && choice > 0)
            {
                if (isValidMove(choice))
                {
                    mybord[choice - 1] = symbol;
                    updated = true;
                }
                else
                { 
                    Console.WriteLine("invald move , try again");
                }
            }
            else
            {
                throw new Exception("error , please enter number between (1-9)");
                //Console.WriteLine("error , please enter number between (1-9)");
            }
            return updated;
        }
        public bool isValidMove(int choice)
        {
            return char.IsDigit(mybord[choice - 1]);
        }
        public void reset()
        {
            for (int i = 0; i < mybord.Length; i++)
            {
                mybord[i] = (char)('1' + i); //  '0' + i => convert number to ascicode then then return to char 
            }
        }
    }
}
