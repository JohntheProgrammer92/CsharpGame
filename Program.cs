using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGen;
using CharacterGen;
using MyUtilities;

namespace CSharpProject
{
    class Program
    {
        static Player player;
        static Board board;
        static List<Monster> monsterList;

        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 40);
            Console.CursorVisible = false;

            

            player = new Player(100, 5, 1, "John");
            NewLevel(1); // Create level 1

            while (true)
            {
                HUD(board, player);
                player.Move(board);
                if (board.board[player.row, player.col].stairsHere)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You ascend the tower!");
                    Console.ReadKey();
                    NewLevel(board.level+1);
                    continue;
                }

                //Monster movement and death
                for (int i=0; i < monsterList.Count; i++) 
                {
                    if (monsterList[i].health <= 0)
                    {
                        monsterList[i].Death(board);
                        monsterList.RemoveAt(i);
                        continue;
                    }
                    monsterList[i].Move(board, player);
                }

                if (player.health <= 0)
                {
                    player.Death(board);
                    Utils.Message("You are dead.");
                    Console.ReadKey();
                    break;
                }
            }                
        }

        //Generates a new level. Called when stairs are reached
        static void NewLevel(int level)
        {
            board = new Board(60, 30, level);
            monsterList = new List<Monster>(); //reset monster list

            //Adds random monsters to board.
            for (int i = 0; i <= level; i++)
            {
                int x = StaticRandom.Instance.Next(board.level, 30 + board.level);          
                if (x <= 23)
                {
                    int health = StaticRandom.Instance.Next(5, 10 + board.level);
                    string symbol = "Z";
                    monsterList.Add(new Monster(1, health, 1, true, symbol));
                }
                else if (x <= 30)
                {
                    int attack = StaticRandom.Instance.Next(7, 10 + board.level);
                    int health = StaticRandom.Instance.Next(30, 50 + (board.level*2));                    
                    //monsterList.Add(new Orc(attack, health, 5, true));
                }
                else if (x <= 42)
                {                    
                    int health = StaticRandom.Instance.Next(35, 45 + (board.level * 3));
                    //monsterList.Add(new Archer(1, 40, 5, true));
                }
                else if (x <= 50)
                {                    
                    int health = StaticRandom.Instance.Next(20, 30 + (board.level * 2));
                    //monsterList.Add(new Wizard(1, 20, 5, true));
                }
            }

            board.PlaceActor(player);
            foreach (Monster m in monsterList)
            {
                board.PlaceActor(m);
            }
            board.ShowBoard();
        }

        //Displays right player HUD
        static void HUD(Board b, Player p)
        {
            Console.SetCursorPosition(board.width + 5, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Health: " + player.health.ToString()); Console.Write("    ");
            Console.SetCursorPosition(board.width + 5, 12);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Attack: " + player.attack.ToString()); Console.Write("    ");
            Console.SetCursorPosition(board.width + 5, 14);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Score: " + player.score.ToString()); Console.Write("    ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(board.width + 5, 16);
            Console.Write("DLvl: " + board.level.ToString()); Console.Write("    ");
        }
    }
}
