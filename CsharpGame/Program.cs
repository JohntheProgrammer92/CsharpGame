using System;

namespace CsharpGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board map = new Board(10, 10);
            map.Makeroom(5, 5, 2, 2);
            Console.WriteLine(map);
            Console.ReadLine();

        }
    }
}
