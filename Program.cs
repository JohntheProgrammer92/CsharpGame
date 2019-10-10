//John  Boner Csharp fall 19
using System;

namespace CsharpGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = 100;
            int width = 100;
            int numRooms = 4;
            
            

            Board map = new Board(height, width, numRooms);
            Console.ReadLine();

        }
    }
}
