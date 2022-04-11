using System;

namespace Skiing_Amongst_Trees
{
    public class SkiBoard
    {
        public char [,] board;
        public int columnCounter;
        public int rowCounter;
        public (int, int) currentPosition = (0,0);
        public int treeHitAmount;
        public SkiBoard()
        {
            rowCounter = 0;
            columnCounter = 0;
        }
        private SkiBoard(int rowCounter, int columnCounter)
        {
            board = new char[rowCounter, columnCounter];
        }

        public SkiBoard createSkiBoard(string filePath, SkiBoard skiBoard)
        //This method takes in a filePath and a skiBoard instance and returns a SkiBoard after creating the rows and columns using the file.
        {
            string line;
            skiBoard = skiBoard.getRowsAndColumns(filePath, skiBoard);

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

        private SkiBoard getRowsAndColumns (string filePath, SkiBoard skiBoard)
        //This method sets rowCounter and columnCounter for a SkiBoard object.
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
            return skiBoard;
        }
        public void updatePosition(int slopeColumn, int slopeRow, SkiBoard skiBoard)
        //This method updates the position of the skiier based on the slope currently being used.
        {
            var futurePosition = skiBoard.currentPosition.Item2 + slopeColumn;
            
            if(futurePosition <= columnCounter-1)
            {
                skiBoard.currentPosition.Item1 += slopeRow;
                skiBoard.currentPosition.Item2 += slopeColumn;
            }
            else
            {
                futurePosition = futurePosition - skiBoard.columnCounter;
                skiBoard.currentPosition.Item1 += slopeRow;
                skiBoard.currentPosition.Item2 = futurePosition;
            }
        }

        public (int,int) traverseMountain(int slopeColumn, int slopeRow, SkiBoard skiBoard)
        //This method continiously traverses the mountain, having the skiier go from the top row to the bottom row.
        {
            skiBoard.currentPosition = (0, 0);
            var rowImOn = 0;
            while(rowImOn < rowCounter)
            {
                checkForTreeHit(skiBoard);
                updatePosition(slopeColumn, slopeRow, skiBoard);
                rowImOn++;
            }
            return skiBoard.currentPosition;
        }

        private void checkForTreeHit(SkiBoard skiBoard)
        //This method just checks if a tree is hit or not at the current position.
        {
            if (skiBoard.currentPosition.Item1 < rowCounter && skiBoard.currentPosition.Item2 < columnCounter)
            {
                if (board[skiBoard.currentPosition.Item1, skiBoard.currentPosition.Item2] == '#')
                {
                    treeHitAmount++;
                }
            }
        }

        public (int, int) findBestSlope(SkiBoard skiBoard)
        //This method returns the slope as a (int, int) after finding the slope that hits the lowest amount of trees.
        {
            (int, int) bestSlope = (0, 1);
            (int, int) testSlope = (0, 1);
            int lowestTreeAmount = int.MaxValue;

            for (int i = 0; i < columnCounter - 1; i++)
            {
                testSlope = (i, 1);

                skiBoard.treeHitAmount = 0; //Reset the treeHitAmount to zero because that is what were testing.
                traverseMountain(testSlope.Item1, testSlope.Item2, skiBoard);
                

                if (skiBoard.treeHitAmount < lowestTreeAmount)
                {
                    lowestTreeAmount = skiBoard.treeHitAmount;
                    bestSlope = testSlope;
                }
                skiBoard.currentPosition = (0, 0);
            }

            return bestSlope;
        }
    }
}
