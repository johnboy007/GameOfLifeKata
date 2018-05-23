namespace GameOfLifeKata
{
    public class Cell
    {
        public int Row { get; }
        public int Column { get; }
        public bool Alive { get; set; }

        public Cell(int row, int column, bool alive = true)
        {
            Row = row;
            Column = column;
            Alive = alive;
        }
    }
}