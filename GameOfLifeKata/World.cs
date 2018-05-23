using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeKata
{
    public class World
    {
        public Generation CurrentGeneration { get; set; }

        public int GenerationCounter { get; set; }

        /// <summary>
        ///     Constructor for a new world
        /// </summary>
        /// <param name="intitialGeneration"></param>
        public World(Generation intitialGeneration)
        {
            CurrentGeneration = intitialGeneration;
        }

        /// <summary>
        ///     Evolve will update the cells and create a new generation
        /// </summary>
        public void Evolve()
        {
            //Copy the cells into a nextgeneration of cells list
            var nextGenerationCells = new List<Cell>();
            foreach (var cell in CurrentGeneration.Cells)
                nextGenerationCells.Add(new Cell(cell.Row, cell.Column, cell.Alive));

            //Update the cells by the rules
            UpdateCellsByWorldRules(ref nextGenerationCells);

            //Get the alive cells only
            var aliveCells = new List<Cell>();
            foreach (var nextGenerationCell in nextGenerationCells)
            {
                if(nextGenerationCell.Alive)
                    aliveCells.Add(nextGenerationCell);
            }

            //Create a new generation
            CurrentGeneration = new Generation(CurrentGeneration.RowCount, CurrentGeneration.ColumnCount, aliveCells);
        }

        private void UpdateCellsByWorldRules(ref List<Cell> Cells)
        {
            foreach (var cell in Cells)
            {
                var livingNeighbourCount = GetLivingNeighbourCount(cell);
                var isAlive = cell.Alive;
                cell.Alive = false;

                if (isAlive)
                {
                    if (livingNeighbourCount < 2)
                        cell.Alive = false; //The Under-Population Rule
                    else if (livingNeighbourCount == 2 || livingNeighbourCount == 3)
                        cell.Alive = true; //The Survival Rule
                    else if (livingNeighbourCount > 3)
                        cell.Alive = false; //The Overcrowding Rule
                }
                else if (livingNeighbourCount == 3)
                    cell.Alive = true; //The Birth Rule
            }

            GenerationCounter++;
        }

        private int GetLivingNeighbourCount(Cell cell)
        {
            var count = 0;

            // Check cell on the right.
            if (cell.Row != CurrentGeneration.RowCount - 1)
                if (IsCellAlive(cell.Row + 1, cell.Column))
                    count++;

            // Check cell on the bottom right.
            if (cell.Row != CurrentGeneration.RowCount - 1 && cell.Column != CurrentGeneration.ColumnCount - 1)
                if (IsCellAlive(cell.Row + 1, cell.Column + 1))
                    count++;

            // Check cell on the bottom.
            if (cell.Column != CurrentGeneration.ColumnCount - 1)
                if (IsCellAlive(cell.Row, cell.Column + 1))
                    count++;

            // Check cell on the bottom left.
            if (cell.Row != 0 && cell.Column != CurrentGeneration.ColumnCount - 1)
                if (IsCellAlive(cell.Row - 1, cell.Column + 1))
                    count++;

            // Check cell on the left.
            if (cell.Row != 0)
                if (IsCellAlive(cell.Row - 1, cell.Column))
                    count++;

            // Check cell on the top left.
            if (cell.Row != 0 && cell.Column != 0)
                if (IsCellAlive(cell.Row - 1, cell.Column - 1))
                    count++;

            // Check cell on the top.
            if (cell.Column != 0)
                if (IsCellAlive(cell.Row, cell.Column - 1))
                    count++;

            // Check cell on the top right.
            if (cell.Row != CurrentGeneration.RowCount - 1 && cell.Column != 0)
                if (IsCellAlive(cell.Row + 1, cell.Column - 1))
                    count++;

            return count;
        }

        public bool IsCellAlive(int row, int column)
        {
            foreach (var cell in CurrentGeneration.Cells)
                if (cell.Row == row && cell.Column == column)
                    return cell.Alive;
            return false;
        }

        public bool CellsMatchGeneration(IEnumerable<Cell> Cells)
        {
            return !(from cell in Cells from cellCurrent in CurrentGeneration.Cells where cell.Row == cellCurrent.Row && cell.Column == cellCurrent.Column where cell.Alive != cellCurrent.Alive select cell).Any();
        }
    }
}