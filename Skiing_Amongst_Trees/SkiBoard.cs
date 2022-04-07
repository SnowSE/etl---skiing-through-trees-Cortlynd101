using System;

namespace Skiing_Amongst_Trees
{
    public class SkiBoard
    {
        public char [,] board;
        public int columnCounter;
        public int rowCounter;

        public SkiBoard()
        {

        }
        public SkiBoard(int rowCounter, int columnCounter)
        {
            board = new char[rowCounter, columnCounter];
        }

        public SkiBoard createSkiBoard(string filePath, SkiBoard skiBoard)
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            skiBoard.columnCounter = 0;
            skiBoard.rowCounter = 0;

            while ((line = file.ReadLine()) != null)
            {
                if (rowCounter == 0)
                {
                    foreach (var character in line.ToCharArray())
                    {
                        skiBoard.columnCounter++;
                    }
                }
                skiBoard.rowCounter++;
            }

            skiBoard = new SkiBoard(rowCounter, columnCounter);

            skiBoard.columnCounter = 0;
            skiBoard.rowCounter = 0;

            while ((line = file.ReadLine()) != null)
            {
                foreach (var character in line.ToCharArray())
                {
                    skiBoard.board[rowCounter, columnCounter] = character;
                    skiBoard.columnCounter++;
                }
                skiBoard.rowCounter++;
            }

            file.Close();

            return skiBoard;
        }
    }
}
