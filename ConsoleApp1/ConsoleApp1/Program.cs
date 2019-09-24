using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            string Input(string x)
            {
                Console.Write(x);
                string userInput = Console.ReadLine();
                return userInput;
            }

            

            string[] dieType = { "d4", "d6", "d10", "d20" };

            while (true)
            {
                Console.WriteLine("");
                string dType = Input("Please choose the kind of die to roll: (d4, d6, d10, d20) |*| (x) to quit: ");
                if (dieType.Contains(dType))
                {
                    while (true)
                    {
                        Console.WriteLine("");
                        string numRoll = Input("Please choose the number of dice to roll |*| (x) to go back: ");
                        if (int.TryParse(numRoll, out int numRollInt))
                        {
                            while (true)
                            {

                                Console.WriteLine("");
                                string target = Input("What is your target roll? |*| (x) to go back: ");
                                if (int.TryParse(target, out int targetInt))
                                {
                                    for (int x = 0; x < numRollInt; ++x)
                                    {
                                        if (x >= targetInt)
                                        {
                                            Console.WriteLine(x);
                                            Console.WriteLine("Passed!");
                                            Console.WriteLine("");

                                        }
                                        else if (x < targetInt)
                                        {
                                            Console.WriteLine(x);
                                            Console.WriteLine("Failed!");
                                            Console.WriteLine("");
                                        }
                                    }
                                }
                                else if (target == "x")
                                {
                                    Console.WriteLine("");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a target number!");
                                }
                            }




                        }
                        else if (numRoll == "x")
                        {
                            Console.WriteLine("");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a number!");
                        }



                    }
                }
                else if (dType == "x")
                {
                    Console.WriteLine("");
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid die type!");
                }
                }
            }
        }
    }
