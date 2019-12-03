using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGen;
using MyUtilities;


namespace CharacterGen
{
    class Assassin : Monster
    {


        bool hostile;
        public int row { get; set; }
        public int col { get; set; }
        public string symbol { get; }
        public int speed { get; }
        public ConsoleColor color { get; }
        public string name { get; set; }

        public Assassin(int atk, int hp, int lvl, bool hos, string sym = "*", ConsoleColor c = ConsoleColor.White) : base(atk, hp, lvl, hos, sym, c)
        {
            attack = atk;
            health = hp;
            level = lvl;
            hostile = hos;
            row = 0;
            col = 0;
            symbol = sym;
            color = c;
            name = "Assassin";
        }

        public override string ToString()
        {
            string returnString = "";
            returnString += "Health: " + health + Environment.NewLine;
            returnString += "Level: " + level + Environment.NewLine;
            if (hostile)
            {
                returnString += "The Assassin stares with ill intent.";
            }
            else
            {
                returnString += "You feel like you're being watched, yet unthreatened";
            }
            return returnString;
        }

        public virtual void Death(Board b)
        {
            Utils.Message("The " + name + " breathes its final breath!", color);
            b.board[row, col].occupied = null;
        }

        public virtual void Interact(Board b, IActor a)
        {

            Utils.Message(name + " swiftly stabs " + a.name, color);
            a.health -= attack - a.defense;
            Console.ReadKey();

        }

        //Default move... to move randomly
        public override void Move(Board b, Player p = null)
        {
            int chance = 50;
            int tryTele = StaticRandom.Instance.Next(chance - chance, chance + chance);
            bool tele = false;
            if(tryTele > chance)
            {
                tele = true;
            }
            if (tele)
            {
                int pos = StaticRandom.Instance.Next(0, 4);
                if(pos == 0 && b.board[p.row-1,p.col].symbol != "#")
                {
                    row = p.row - 1;
                    col = p.col;
                    b.board[row, col].occupied = this;
                    b.ShowTile(row, col);
                    Interact(b, p);

                }
                if (pos == 1 && b.board[p.row + 1, p.col].symbol != "#")
                {
                    row = p.row + 1;
                    col = p.col;
                    b.board[row, col].occupied = this;
                    b.ShowTile(row, col);
                    Interact(b, p);

                }
                if (pos == 2 && b.board[p.row, p.col - 1].symbol != "#")
                {
                    row = p.row;
                    col = p.col - 1;
                    b.board[row, col].occupied = this;
                    b.ShowTile(row, col);
                    Interact(b, p);

                }
                if (pos == 3 && b.board[p.row, p.col + 1].symbol != "#")
                {
                    row = p.row;
                    col = p.col + 1;
                    b.board[row, col].occupied = this;
                    b.ShowTile(row, col);
                    Interact(b, p);

                }
            }


            b.board[row, col].occupied = this;
            b.ShowTile(row, col);
        }
    }
}
