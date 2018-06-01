using System;
using System.Collections.Generic;
using System.Threading;
using GameOfLifeKata;

namespace GameOfLifeConsole
{
    internal class Program
    {
        private const int MaxEvolutionCount = 30;

        private enum Pattern : short
        {
            Beacon = 0,
            Blinker = 1,
            Pulsar = 2,
            Glider = 3
        }

        private static void Main(string[] args)
        {
            ReadKeys();
        }

        private static void ReadKeys()
        {
            Console.Clear();
            Console.WriteLine("\r F1: Blinker");
            Console.WriteLine("\r F2: Beacon");
            Console.WriteLine("\r F3: Glider");
            Console.WriteLine("\r F4: Pulsar");
            Console.WriteLine("\r Esc: Exit");

            var key = Console.ReadKey();

            while (!Console.KeyAvailable)
            {
                switch (key.Key)
                {
                    case ConsoleKey.F1:
                        Start(Pattern.Blinker);
                        break;
                    case ConsoleKey.F2:
                        Start(Pattern.Beacon);
                        break;
                    case ConsoleKey.F3:
                        Start(Pattern.Glider);
                        break;
                    case ConsoleKey.F4:
                        Start(Pattern.Pulsar);
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static void Start(Pattern pattern)
        {
            var rowCount = 0;
            var colCount = 0;
            var lstCell = GetPattern(pattern, ref rowCount, ref colCount);
            var intitialGeneration = new Generation(rowCount, colCount, lstCell);

            var world = new World(intitialGeneration);
            var evolutionCount = 0;
            Console.Clear();
            while (evolutionCount++ <= MaxEvolutionCount)
            {
                DrawGame(pattern, world);
                world.Evolve();
                Thread.Sleep(500);
            }

            ReadKeys();
        }

        private static List<Cell> GetPattern(Pattern pattern, ref int rowCount, ref int colCount)
        {
            List<Cell> lstCell;

            switch (pattern)
            {
                case Pattern.Beacon:
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
                    break;
                case Pattern.Blinker:
                    rowCount = colCount = 5;
                    lstCell = new List<Cell>
                    {
                        new Cell(1, 2),
                        new Cell(2, 2),
                        new Cell(3, 2)
                    };
                    break;
                case Pattern.Pulsar:
                    rowCount = colCount = 15;
                    lstCell = new List<Cell>
                    {
                        new Cell(3, 1),
                        new Cell(4, 1),
                        new Cell(5, 1),
                        new Cell(9, 1),
                        new Cell(10, 1),
                        new Cell(11, 1),

                        new Cell(3, 6),
                        new Cell(4, 6),
                        new Cell(5, 6),
                        new Cell(9, 6),
                        new Cell(10, 6),
                        new Cell(11, 6),

                        new Cell(3, 8),
                        new Cell(4, 8),
                        new Cell(5, 8),
                        new Cell(9, 8),
                        new Cell(10, 8),
                        new Cell(11, 8),

                        new Cell(3, 13),
                        new Cell(4, 13),
                        new Cell(5, 13),
                        new Cell(9, 13),
                        new Cell(10, 13),
                        new Cell(11, 13),

                        new Cell(1, 3),
                        new Cell(1, 4),
                        new Cell(1, 5),
                        new Cell(1, 9),
                        new Cell(1, 10),
                        new Cell(1, 11),

                        new Cell(6, 3),
                        new Cell(6, 4),
                        new Cell(6, 5),
                        new Cell(6, 9),
                        new Cell(6, 10),
                        new Cell(6, 11),

                        new Cell(8, 3),
                        new Cell(8, 4),
                        new Cell(8, 5),
                        new Cell(8, 9),
                        new Cell(8, 10),
                        new Cell(8, 11),

                        new Cell(13, 3),
                        new Cell(13, 4),
                        new Cell(13, 5),
                        new Cell(13, 9),
                        new Cell(13, 10),
                        new Cell(13, 11)
                    };
                    break;
                case Pattern.Glider:
                    rowCount = colCount = 20;
                    lstCell = new List<Cell>
                    {
                        new Cell(1, 0),
                        new Cell(1, 2),
                        new Cell(2, 1),
                        new Cell(2, 2),
                        new Cell(3, 1)
                    };
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pattern), pattern, null);
            }

            return lstCell;
        }

        private static void DrawGame(Pattern pattern, World world)
        {
            Console.WriteLine($"{pattern}\r");
            Console.WriteLine($"Evolution counter : {world.GenerationCounter} of {MaxEvolutionCount}");
            for (var i = 0; i < world.CurrentGeneration.RowCount; i++)
            {
                for (var j = 0; j < world.CurrentGeneration.ColumnCount; j++)
                {
                    Console.Write(world.IsCellAlive(i, j) ? "x" : " ");

                    if (j == world.CurrentGeneration.ColumnCount - 1)
                    {
                        Console.WriteLine("\r");
                    }
                }
            }

            Console.SetCursorPosition(0, Console.WindowTop);
        }
    }
}