using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    class Program
    {
        static void Main(string[] args)
        {
            bool loop = true;
            while(loop){
                Console.Clear();
                PlayerGen character = new PlayerGen();
                Console.WriteLine(character);
                Console.WriteLine("do you like this character?: (y) to keep / (x) to quit / any other key to re-roll.");
                System.ConsoleKeyInfo input = Console.ReadKey();
                if(input.Key == ConsoleKey.Y)
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Congradulations");
                    Console.ReadKey();
                    loop = false;
                }
                if(input.Key == ConsoleKey.X)
                {
                    loop = false;
                }


            }

        }
    }
}
