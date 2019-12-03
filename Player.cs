using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGen;
using MyUtilities;

namespace CharacterGen
{
    class Player : GameCharacter, IActor
    {
        public int score { get; set; }
        public string history { get; }
        public int row { get; set; }
        public int col { get; set; }
        public string symbol { get; }
        public int speed { get; }
        public ConsoleColor color { get; }
        public string name { get; set; }

        public Player(int hp, int atk, int lvl, string n = "Default Loser")
        {
            health = hp;
            attack = atk;
            level = lvl;
            row = 0;
            col = 0;
            name = n;
            symbol = "@";
            color = ConsoleColor.Red;
        }       
        
        public override string ToString()
        {
            string returnString = "";
            returnString += "Name: " + name + Environment.NewLine;
            returnString += "Health: " + health + Environment.NewLine;
            returnString += "Level: " + level + Environment.NewLine;
            return returnString;
        }

        public void Death(Board b)
        {
            Utils.Message("Your wounds have become too greivous...", ConsoleColor.Red);
            System.Threading.Thread.Sleep(3500);
            Utils.Message("Everything begins to fade...", ConsoleColor.DarkRed);
            Console.ReadKey();
            b.board[row, col].occupied = null;
        }

        //What happens when the player moves into an actor
        public void Interact(Board b, IActor a)
        {
            Utils.Message("You attack the "+ a.name + " for " + attack + " damage!");
            Console.ReadKey();
            a.health -= attack - a.defense;
        }        

        //Handles commands for Player
        public void Move(Board b, Player p = null)
        {            
            Boolean moved = false; //flag for exiting move loop. Allows for the player to do things besides move and it won't trigger an enemy turn.
            while (moved == false)
            {
                //get user command
                Utils.Message("Command:");
                ConsoleKeyInfo k = Console.ReadKey(true);
                char input = char.ToUpper(k.KeyChar);                

                //init new row and col so we can adjust and validate before assigning
                int newRow = row;
                int newCol = col;
                //move if not wall or occupied                
                
                if (k.Key == ConsoleKey.DownArrow)
                {                   
                    newRow += 1;                   
                }
                
                else if (k.Key == ConsoleKey.LeftArrow)
                {             
                    newCol -= 1;                  
                }
                else if (k.Key == ConsoleKey.RightArrow)
                {                   
                    newCol += 1;                   
                }
                
                else if (k.Key == ConsoleKey.UpArrow)
                {
                    newRow -= 1;
                }
                
                else //no valid command entered
                {
                    continue; 
                }

                //determine results of command - see if occupied or wall before moving
                if (b.board[newRow,newCol].occupied != null && b.board[newRow, newCol].occupied != this)
                {
                    Interact(b,b.board[newRow, newCol].occupied);
                    moved = true;
                }
                else if (b.board[newRow, newCol].symbol == "#")
                {
                    Console.SetCursorPosition(0, b.height + 1);
                    Console.Write("That is a wall...");
                    Console.ReadKey();
                }
                else
                {                    
                    moved = true;
                }

                if (moved) //this is everything that triggers when a player moves
                {
                    //remove player from current location and redisplay tile
                    b.board[row, col].occupied = null;
                    b.ShowTile(row, col);

                    //add player to new location
                    row = newRow;
                    col = newCol;                    
                    b.board[row, col].occupied = this;
                    b.ShowTile(row, col);                 
                }

            }

        }
    }
}
