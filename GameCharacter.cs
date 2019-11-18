using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterGen
{
    abstract class GameCharacter
    {
        public int health { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int level { get; protected set; }
    }
}
