using System;

namespace CsharpGame
{
    class Board
    {
        private int _height;
        private int _width;
        private Tile[,] _board;

        public Board(int h = 5, int w = 5)
        {
            _height = h;
            _width = w;
            _board = new Tile[w, h];

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _board[x, y] = new Tile();
                }
            }
        }
        public void Makeroom(int h, int w, int srow, int scol)
        {
            for (int i = scol; i < h + scol; i++)
            {
                for (int j = srow; j < w + srow; j++)
                {
                    _board[i, j] = new Tile('.', ConsoleColor.Green, ConsoleColor.White, false);
                }
            }


        }

        public override string ToString()
        {
            string returnString = "";
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    if (_board[x, y].ToString() == ".")
                    {
                        Console.ForegroundColor = _board[x, y].Fore();
                        Console.BackgroundColor = _board[x, y].Back();
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    returnString += _board[x, y];
                }
                returnString += Environment.NewLine;
            }
            return returnString;

        }
    }
}
