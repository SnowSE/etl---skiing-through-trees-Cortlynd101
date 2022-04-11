using System;

namespace Skiing_Amongst_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Cortl\Source\Repos\etl---skiing-through-trees-Cortlynd101\Skiing_Amongst_Trees\TreeMap.txt";
            SkiBoard skiBoard = new SkiBoard();
            skiBoard = skiBoard.createSkiBoard(filePath, skiBoard);

            //string lineToBePrinted = "";

            //for (int i = 0; i < skiBoard.rowCounter; i++)
            //{
            //    for (int j = 0; j < skiBoard.columnCounter; j++)
            //    {
            //        lineToBePrinted = lineToBePrinted + skiBoard.board[i, j];
            //    }
            //    Console.WriteLine("\n" + lineToBePrinted);
            //}

            (int, int) bestSlope = skiBoard.findBestSlope(skiBoard);
            Console.WriteLine($"Best slope: {bestSlope}");

            (int, int) finalPosition = skiBoard.traverseMountain(3, 1, skiBoard);
            Console.WriteLine($"Final position: {finalPosition}");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
