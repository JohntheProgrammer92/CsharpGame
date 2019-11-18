using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterGen;
using MyUtilities;

namespace BoardGen
{
	class Board
	{
		private int _numRooms;
		List<int[]> midPoints = new List<int[]>(20);

        public int width;
		public int height;
		public Tile[,] board;
        public int level;

		public Board(int w = 60, int h = 30, int lvl = 1)
		{
			height = h;
			width = w;
            level = lvl;
			board = new Tile[height, width];

            //Create blank board of walls ( # )
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					board[i, j] = new Tile("#");
					board[i,j].color = ConsoleColor.DarkBlue;
				}
			}
            //Create 4 to 10 rooms
			MakeRooms(StaticRandom.Instance.Next(4, 11), height, width);
            MakeCorridor();     
            PlaceStairs();                       
        }
        
        //Creates a certain number of rooms by validating random coords then sending coords to MakeRoom()
        public void MakeRooms(int rooms, int height, int width)
		{
            _numRooms = rooms; //capture the amount of rooms in the level
			while (true)
			{
				int CoorHeight = StaticRandom.Instance.Next(1, height - 3);
				int CoorWidth = StaticRandom.Instance.Next(1, width - 3);
				int RoomHeight = StaticRandom.Instance.Next(5, 10);
				int RoomWidth = StaticRandom.Instance.Next(5, 10);

                //Room Size validation
				if (CoorHeight + RoomHeight < height - 1 && CoorWidth + RoomWidth < width - 1)
				{
					rooms--;
					MakeRoom(CoorHeight, CoorWidth, RoomHeight, RoomWidth);
					int[] center = new int[] { CoorHeight + (RoomHeight/2), CoorWidth + (RoomWidth/2) };
					midPoints.Add(center);

					if (rooms == 0)	{break;	}                    
				}
			}
		}

        //Creates a Room of a given size at a given location
        public void MakeRoom(int CoorHeight, int CoorWidth, int RoomHeight, int RoomWidth)
		{
			for (int i = CoorHeight; i < CoorHeight + RoomHeight; i++)
			{
				for (int j = CoorWidth; j < CoorWidth + RoomWidth; j++)
				{
					board[i, j] = new Tile(".");
				}
			}
		}

        //Carves hallways to connect rooms during level creation
        public void MakeCorridor()
        {
            for (int i = 1; i < midPoints.Count; i++)
            {
                if (midPoints[i - 1][0] < midPoints[i][0])
                {
                    for (int row = midPoints[i - 1][0]; row <= midPoints[i][0]; row++)
                    {
                        board[row, midPoints[i][1]] = new Tile(".");
                    }
                }
                else if (midPoints[i - 1][0] > midPoints[i][0])
                {
                    for (int row = midPoints[i - 1][0]; row >= midPoints[i][0]; row--)
                    {
                        board[row, midPoints[i][1]] = new Tile(".");
                    }
                }
                if (midPoints[i - 1][1] < midPoints[i][1])
                {
                    for (int columnD = midPoints[i][1]; columnD >= midPoints[i - 1][1]; columnD--)
                    {
                        board[midPoints[i - 1][0], columnD] = new Tile(".");
                    }
                }
                else if (midPoints[i - 1][1] > midPoints[i][1])
                {
                    for (int columnU = midPoints[i][1]; columnU <= midPoints[i - 1][1]; columnU++)
                    {
                        board[midPoints[i - 1][0], columnU] = new Tile(".");
                    }
                }
            }
        }

        //Places Stairs on the map
        public void PlaceStairs()
		{
			while (true)
			{
				int c = StaticRandom.Instance.Next(1, height);
				int r = StaticRandom.Instance.Next(1, width);
				if (board[c, r].symbol == ".")
				{
					board[c, r].stairsHere = true;
					break;
				}
			}
		} 

        //Places Player on the Map
        public void PlaceActor(IActor a)
		{
			while (true)
			{
				int c = StaticRandom.Instance.Next(1, width);
				int r = StaticRandom.Instance.Next(1, height);
				if (board[r, c].symbol == "." && board[r, c].occupied == null)
				{
					board[r, c].occupied = a;
                    a.row = r;
                    a.col = c;
					break;  
				}
			}
		}

        //Handles everything about Tile Display. 
        public void ShowTile(int row, int col)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = board[row, col].color;
            if (board[row, col].occupied != null)
            {
                Console.ForegroundColor = board[row, col].occupied.color;
                Console.Write(board[row, col].occupied.symbol);
            }
            else if (board[row, col].stairsHere)
            {
                Console.Write(">");
            }
            else
            {   
                Console.Write(board[row, col].symbol);
            }
        }

        //Prints the full board. Usually only needed after screen is cleared
        public void ShowBoard()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    ShowTile(i, j);
                }
                Console.Write("\n");
            }
        }
    }
}

		
	


