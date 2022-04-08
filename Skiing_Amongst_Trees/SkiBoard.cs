using System;

namespace Skiing_Amongst_Trees
{
    public class SkiBoard
    {
        public char [,] board;
        public int columnCounter;
        public int rowCounter;
        public (int, int) currentPosition = (0,0);
        public SkiBoard()
        {
            rowCounter = 0;
            columnCounter = 0;
        }
        public SkiBoard(int rowCounter, int columnCounter)
        {
            board = new char[rowCounter + 1, columnCounter + 1];
        }

        public SkiBoard createSkiBoard(string filePath, SkiBoard skiBoard)
        //This method takes in a filePath and a skiBoard instance and returns a SkiBoard after creating the rows and columns using the file.
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            skiBoard.rowCounter = 0;
            skiBoard.columnCounter = 0;

            while ((line = file.ReadLine()) != null)
            {
                if (skiBoard.rowCounter == 0)
                {
                    foreach (var character in line.ToCharArray())
                    {
                        skiBoard.columnCounter++;
                    }
                }
                skiBoard.rowCounter++;
            }
            file.Close();

            int columnCounterValueSaved = columnCounter; //This is needed so that columnCounter is not zero after running all this.
            skiBoard = new SkiBoard(rowCounter, columnCounter);

            System.IO.StreamReader fileReadAgain = new System.IO.StreamReader(filePath); //We have to read through the file again so that line is no longer null.
            skiBoard.rowCounter = 0;
            skiBoard.columnCounter = 0;

            while ((line = fileReadAgain.ReadLine()) != null)
            {
                foreach (var character in line.ToCharArray())
                {
                    skiBoard.board[skiBoard.rowCounter, skiBoard.columnCounter] = character;
                    skiBoard.columnCounter++;
                }
                skiBoard.columnCounter = 0;
                skiBoard.rowCounter++;
            }

            skiBoard.columnCounter = columnCounterValueSaved; //Here we set columnCounter to the value we saved earlier.
            fileReadAgain.Close();
            return skiBoard;
        }

        public void updatePosition(int slopeColumn, int slopeRow)
        //This method updates the position of the skiier based on the slope currently being used.
        {
            var futurePosition = currentPosition.Item2 + slopeColumn;
            
            if(futurePosition <= columnCounter)
            {
                currentPosition.Item1 += slopeRow;
                currentPosition.Item2 += slopeColumn;
            }
            else
            {
                futurePosition = futurePosition - columnCounter - 1;
                currentPosition.Item1 += slopeRow;
                currentPosition.Item2 = futurePosition;
            }
        }

        public (int,int) traverseMountain(int slopeColumn, int slopeRow)
        //This method continiously traverses the mountain, having the skiier go from the top row to the bottom row.
        {
            var rowImOn = 0;
            while(rowImOn < rowCounter)
            {
                updatePosition(slopeColumn, slopeRow);
                rowImOn++;
            }
            Console.WriteLine("End position is {0}", currentPosition);
            return currentPosition;
        }
    }
}
