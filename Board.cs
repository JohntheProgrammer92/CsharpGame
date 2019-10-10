using System;
using System.Collections.Generic;

namespace CsharpGame
{
    class Board
    {
        //class to generate a board
        private int _height;
        private int _width;
        private int _rooms;
        private Tile[,] _board;
        private List<int[]> _midpoint = new List<int[]>();

        public Board(int h = 5, int w = 5, int n = 10)
        {
            _height = h;
            _width = w;
            _rooms = n;
            _board = new Tile[h, w];
            

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _board[y, x] = new Tile();
                }
            }
            CreateRooms(n, w, h);            
            BuildCoridor();
            PlaceStairs();
            ShowBoard();
            

        }
        public void MakeRoom(int h, int w, int scol, int srow)
        {
            // method for generating a room in the board
            for (int y = scol; y < h + scol; y++)
            {
                for (int x = srow; x < w + srow; x++)
                {
                    _board[y, x] = new Tile('.',f: ConsoleColor.Green, b: ConsoleColor.White, false);
                    _midpoint.Add(new int[]{h/2+scol, w/2+srow});

                }
            }

            

        }
        public void BuildCoridor()
        {
            for(int i = 1; i < _midpoint.Count; i++)
            {
                int[] mid2 = _midpoint[i];
                int[] mid1 = _midpoint[i - 1];
                if(mid1[0] < mid2[0])
                {
                    for(int r = mid1[0]; r<mid2[0]; r++)
                    {
                        _board[r, mid1[1]] = new Tile('.', f: ConsoleColor.Green, b: ConsoleColor.White, false);
                    }
                }
                else
                {
                    for (int r = mid1[0]; r > mid2[0]; r--)
                    {
                        _board[r, mid1[1]] = new Tile('.', f: ConsoleColor.Green, b: ConsoleColor.White, false);
                    }
                }
                if(mid1[1] < mid2[1])
                {
                    for(int y =mid1[1]; y < mid2[1]; y++)
                    {
                        _board[mid2[0], y] = new Tile('.', f: ConsoleColor.Green, b: ConsoleColor.White, false);
                    }
                }
                else
                {
                    for (int y = mid1[1]; y > mid2[1]; y--)
                    {
                        _board[mid2[0], y] = new Tile('.', f: ConsoleColor.Green, b: ConsoleColor.White, false);
                    }
                }
                
            }
        }

        public void CreateRooms(int n,int h, int w)
        {
            for (int x = 0; x < n; x++)
            {
                while (true)
                {
                    int roomHeight = StaticRandom.Instance.Next(4, h / 8);
                    int roomWidth = StaticRandom.Instance.Next(4, w / 6);
                    int roomStartY = StaticRandom.Instance.Next(1, h - roomHeight - 1);
                    int roomStartX = StaticRandom.Instance.Next(1, w - roomWidth - 1);
                    if (roomStartY + roomHeight < h && roomStartX + roomWidth < w)
                    {
                        MakeRoom(roomHeight, roomWidth, roomStartY, roomStartX);
                        break;
                    }
                }
            }
        }

        public override string ToString()
        {
            string returnString = "";
            for (int y = 0; y < _width; y++)
            {
                for (int x = 0; x < _height; x++)
                {
                    Console.ForegroundColor = _board[y, x].Fore();
                    Console.BackgroundColor = _board[y, x].Back();                    
                    returnString += _board[y, x];
                }
                returnString += Environment.NewLine;
            }
            
            return returnString;
        }

        public void PlaceStairs()
        {
            while (true)
            {
                int stairCol = StaticRandom.Instance.Next(0, _height);
                int stairRow = StaticRandom.Instance.Next(0, _width);
                if (_board[stairCol, stairRow].Symbol() == '.')
                {
                    _board[stairCol, stairRow] = new Tile(sH: true);
                    break;

                }
            }
        }

        public void ShowBoard()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    Console.ForegroundColor = _board[y, x].Fore();
                    Console.BackgroundColor = _board[y, x].Back();
                    Console.Write(_board[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
