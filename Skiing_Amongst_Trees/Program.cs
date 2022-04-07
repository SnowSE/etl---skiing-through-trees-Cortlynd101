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
        }
    }
}
