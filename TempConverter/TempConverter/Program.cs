using System;

namespace TempConverter
{
    class Program
    {
        public static void farenheitConverter(string s)
        {
            if (int.TryParse(s, out int newInt))
            {
                int fTemp = ((newInt *9/5) +32);
                Console.WriteLine(fTemp+" F");
                
            }
        }

        public static void kelvinConverter(string s)
        {
            if (int.TryParse(s, out int newInt))
            {
                double kTemp = (newInt + 273.15);
                Console.WriteLine(kTemp + " K");

            }
        }
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("John's Awesome Celcius To Farenheit And Kelvin Converter");
                Console.WriteLine();
                Console.Write("Please enter a Celcius Temperature: ");
                string userInput = Console.ReadLine();

                farenheitConverter(userInput);
                kelvinConverter(userInput);
                
                Console.WriteLine("Continue (y/n)");
                ConsoleKeyInfo key = Console.ReadKey();
                if(key.KeyChar == 'n')
                {
                    break;
                }
                Console.ReadKey();
            } while (true);
        }
    }
}
