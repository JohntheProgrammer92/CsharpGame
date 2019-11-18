using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardGen;

namespace CharacterGen
{
    interface IActor
    {
        int row { get; set; }
        int col { get; set; }
        string symbol { get; }
        int speed { get; }
        ConsoleColor color { get; }
        int health { get; set; }
        int attack { get; set; }
        int defense { get; set; }
        string name { get; set; }

        void Move(Board b, Player p);
        void Interact(Board b, IActor p);
        void Death(Board b);
    }
}
