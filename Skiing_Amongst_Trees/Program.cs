using System;

namespace Skiing_Amongst_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"E:\Program Files\Git\SnowSE\etl---skiing-through-trees-Cortlynd101\Skiing_Amongst_Trees\TreeMap.txt";
            SkiBoard skiBoard = new SkiBoard();
            skiBoard = skiBoard.createSkiBoard(filePath, skiBoard);

            string lineToBePrinted = "";

            for (int i = 0; i < skiBoard.rowCounter; i++)
            {
                for (int j = 0; j < skiBoard.columnCounter; j++)
                {
                    lineToBePrinted = lineToBePrinted + skiBoard.board[i, j];
                }
                Console.WriteLine("\n" + lineToBePrinted);
            }

           
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
