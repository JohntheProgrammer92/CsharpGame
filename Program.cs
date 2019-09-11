using System;

namespace DieRoller_F2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;



            Console.WriteLine("Please enter the number of times to roll, the number of sides of the dice, and a target number. (or x at any prompt to go back)");
            while (a == 0)
            {
                Console.Write("Input the number of dice: ");
                string times = Console.ReadLine();

                if (int.TryParse(times, out int timesInt))
                {
                    if (timesInt > 0)
                    {
                        int b = 0;
                        while (b == 0)
                        {
                            Console.Write("Input the number of sides per die: ");
                            string sides = Console.ReadLine();

                            if (int.TryParse(sides, out int sidesInt))
                            {
                                int c = 0;
                                while (c == 0)
                                {
                                    Console.Write("Input a target roll: ");
                                    string target = Console.ReadLine();
                                    if (int.TryParse(target, out int targetInt))
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("Your single d6 rolled: " + DieRoller.Roll());
                                        Console.WriteLine("Your " + times + " d6s rolled a total of: " + DieRoller.Roll(timesInt));
                                        Console.WriteLine("Your " + times + " d" + sides + "s rolled a total of: " + DieRoller.Roll(timesInt, sidesInt));
                                        Console.WriteLine("Number of dice that passed the met the target: " + DieRoller.Roll(timesInt, sidesInt, targetInt));
                                        Console.ReadKey();
                                        Console.WriteLine();
                                        Console.WriteLine("Continue? (y/n)");
                                        string sentinal = Console.ReadLine();
                                        if (sentinal == "y")
                                        {
                                            b++;
                                            c++;
                                        }
                                        else if (sentinal == "n")
                                        {
                                            a++;
                                            b++;
                                            c++;
                                        }


                                    }
                                    else if (target == "x")
                                    {
                                        break;
                                    }
                                }
                            }
                            else if (sides == "x")
                            {
                                break;
                            }
                        }
                    }
                }
                else if (times == "x")
                {
                    break;
                }

            }
        }

    }
}
