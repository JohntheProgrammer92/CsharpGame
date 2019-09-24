using System;

namespace CsharpGame
{
    class Tile
    {
        private ConsoleColor _fore;
        private ConsoleColor _back;
        private char _symbol;
        private bool _stairsHere;

        public Tile(char s = '#', ConsoleColor f = ConsoleColor.White, ConsoleColor b = ConsoleColor.Black, bool sH = false)
        {
            _fore = f;
            _back = b;
            _symbol = s;
            _stairsHere = sH;
            if (_stairsHere) { _symbol = '>'; };
        }
        public ConsoleColor Fore()
        {
            return _fore; 
        }
        public ConsoleColor Back()
        {
            return _back;
        }
        public override string ToString()
        {
            string returnString = "";
            returnString += _symbol;
            return returnString;
        }
    }
}
