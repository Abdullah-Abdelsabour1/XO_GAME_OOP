using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace XOGame
{
    internal class Player
    {
        private string playerName;

        private char playerSymbol;

        public Player() :this("Not intilazed" , '0')
        {}
        public Player(string name , char symbol)
        { 
            this.playerName = name;
            this.playerSymbol = symbol;
        }
        // method 
        public void choose_name() 
        {
            Console.WriteLine("Please enter your name (letter only):");
            while (true)
            {
                string name = Console.ReadLine();
                bool isChar = true;
                foreach (var chr in name)
                {
                    if (!char.IsLetter(chr)) // Check if the character is not a letter
                    {
                        isChar = false;
                        break;
                    }
                }
                if (isChar)
                {
                    this.playerName = name; // Assuming 'PlayerName' is a class property
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid name. Please use letters only.");
                    Console.WriteLine("ReEnter your name : ");
                }
            }
        }
        public string printName()
        {
            return playerName;
        }
        public void choose_symbol()
        {
            Console.WriteLine("Please enter your sybmol (only one letter (x or o)):");
            while (true)
            {   
                string symbol = Console.ReadLine();
                if (symbol.Length == 1 && char.IsLetter(symbol[0]))
                {
                    if (char.ToUpper(symbol[0]) == 'X' || char.ToUpper(symbol[0]) == 'O')
                    {
                        this.playerSymbol = symbol[0];
                        break;
                    }
                    else
                    {
                        Console.WriteLine("invalid symbol (Enter one charter only (x or o) )");
                    }
                }
                else
                {
                    Console.WriteLine("invalid symbol (Enter one charter only (x or o) )");
                }
            }
        }
        public char printSymbol()
        {
            return playerSymbol;
        }

    }
}
