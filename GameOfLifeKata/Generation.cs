using System.Collections.Generic;

namespace GameOfLifeKata
{
    /// <summary>
    /// Generation is a state of the world
    /// </summary>
    public class Generation
    {
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public List<Cell> Cells { get; set; }

        public Generation(int rowCount, int coloumnCount, IReadOnlyCollection<Cell> aliveCells)
        {
            RowCount = rowCount;
            ColumnCount = coloumnCount;
            Cells = new List<Cell>();
            CreateMap(aliveCells);
        }

        private void CreateMap(IReadOnlyCollection<Cell> aliveCells)
        {
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < ColumnCount; j++)
                    Cells.Add(new Cell(i, j, false));
            }

            //Map the alive cells
            if (aliveCells.Count <= 0) return;
            foreach (var cell in Cells)
            {
                foreach (var aliveCell in aliveCells)
                {
                    if (cell.Row == aliveCell.Row && cell.Column == aliveCell.Column)
                        cell.Alive = true;
                }
            }
        }
    }
}