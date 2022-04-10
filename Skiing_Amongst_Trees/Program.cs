using System;

namespace Skiing_Amongst_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\brebr\Source\Repos\etl---skiing-through-trees-Cortlynd10\Skiing_Amongst_Trees\TreeMap.txt";
            SkiBoard skiBoard = new SkiBoard();
            skiBoard = skiBoard.createSkiBoard(filePath, skiBoard);

            string lineToBePrinted = "";

            /*for (int i = 0; i < skiBoard.rowCounter; i++)
            {
                for (int j = 0; j < skiBoard.columnCounter; j++)
                {
                    lineToBePrinted = lineToBePrinted + skiBoard.board[i, j];
                }
                Console.WriteLine("\n" + lineToBePrinted);
            }*/

            skiBoard.traverseMountain(3, 1);

            Console.WriteLine($"{skiBoard.currentPosition.Item1},{skiBoard.currentPosition.Item2}");
            Console.WriteLine($"{skiBoard.treeHitAmount}");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
