using System.Collections.Generic;

namespace GameOfLifeKata
{
    public class Generation
    {
        private int RowCount { get; }
        private int ColumnCount { get; }
        public Generation(int rowCount, int coloumnCount, List<Cell> intitialGeneration)
        {
            rowCount = RowCount;
            coloumnCount = ColumnCount;
        }
    }
}