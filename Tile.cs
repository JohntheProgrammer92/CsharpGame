using System;

namespace CsharpGame
{
    class Tile
    {
        // class for tiles
        private ConsoleColor _fore;
        private ConsoleColor _back;
        private char _symbol;
        private bool _stairsHere;

        public Tile(char s = '#', ConsoleColor f = ConsoleColor.Blue, ConsoleColor b = ConsoleColor.Black, bool sH = false)
        {
            _fore = f;
            _back = b;
            _symbol = s;
            _stairsHere = sH;
            if (_stairsHere == true)
            {
                _symbol = '>';
                _fore = ConsoleColor.Red;
            }
        }
        public ConsoleColor Fore()
        {
            // Getter for _fore
            return _fore; 
        }
        public ConsoleColor Back()
        {
            // Getter for _back
            return _back;
        }

        public char Symbol()
        {
            // Getter for _symbol
            return _symbol;
        }

        public override string ToString()
        {
            string returnString = "";
            
            returnString += _symbol;
            return returnString;
        }
    }
}
