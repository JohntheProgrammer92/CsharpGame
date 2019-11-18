using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterGen;

namespace BoardGen
{
	class Tile
	{
		public string symbol { get; set; }
		public ConsoleColor color { get; set; }
		public IActor occupied { get; set; }
		public bool stairsHere { get; set; }

		public Tile(string sym = "#",ConsoleColor c = ConsoleColor.White, bool sh = false, IActor occ = null)
		{
			symbol = sym;
			color = c;
			stairsHere = sh;
            occupied = occ;
		}
	}
}
