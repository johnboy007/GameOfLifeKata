using GameOfLifeKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifeConsole
{
    class Program
    {
        private static World world;

        static void Main(string[] args)
        {
            var lstCell = new List<Cell>();
            var rowCount = 0;
            var colCount = 0;

           // Beacon
            rowCount = colCount = 6;
            lstCell = new List<Cell>
            {
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(2, 1),
                new Cell(3, 4),
                new Cell(4, 3),
                new Cell(4, 4)
            };

            //Blinker
            //rowCount = colCount = 5;
            //lstCell = new List<Cell>
            //{
            //    new Cell(1, 2),
            //    new Cell(2, 2),
            //    new Cell(3, 2)
            //};

            var intitialGeneration = new Generation(rowCount, colCount, lstCell);

            world = new World(intitialGeneration);
            var evolutionCount = 0;
            var maxEvolutionCount = 200;
            while (evolutionCount++ < maxEvolutionCount)
            {
                DrawGame();
                world.Evolve();
                // Set sleep to view the generations
                System.Threading.Thread.Sleep(500);
            }
        }

        private static void DrawGame()
        {
            Console.WriteLine($"Evolution counter : {world.GenerationCounter}");
            for (var i = 0; i < world.CurrentGeneration.RowCount; i++)
            {
                for (var j = 0; j < world.CurrentGeneration.ColumnCount; j++)
                {
                    Console.Write(world.IsCellAlive(i, j) ? "x   " : "0   ");
                    if (j == world.CurrentGeneration.ColumnCount - 1)
                        Console.WriteLine("\r");
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);

        }
    }
}
