namespace GameOfLifeKata
{
    public class World
    {
        private Generation CurrentGeneration { get; }
        public World(Generation intitialGeneration)
        {
            CurrentGeneration = intitialGeneration;
        }

        public void Evolve()
        {
            //Check the grid size 
            //Check the cells alive location
        }
        
        public bool IsCellAlive(int row, int column)
        {
            return false;
        }
    }
}