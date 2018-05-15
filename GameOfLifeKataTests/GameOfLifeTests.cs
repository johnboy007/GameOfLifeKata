using System.Collections.Generic;
using GameOfLifeKata;
using NUnit.Framework;

namespace GameOfLifeKataTests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void ADeadCellWith0NeighboursStaysDead()
        {
            var intitialGeneration = new Generation(3,3,new List<Cell>());
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }

        [Test]
        public void ADeadCellWith1NeighbourStaysDead()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell>{new Cell(0,1)});
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }

        [Test]
        public void ADeadCellWith2NeighboursStaysDead()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell>{new Cell(0,1), new Cell(1,2)});
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }

        [Test]
        public void ADeadCellWith3NeighboursComeToLife()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> {new Cell(0, 0), new Cell(0, 1), new Cell(0, 2)});
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.True);
        }
    }
}
