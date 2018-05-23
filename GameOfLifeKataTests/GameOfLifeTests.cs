using System.Collections.Generic;
using GameOfLifeKata;
using NUnit.Framework;

namespace GameOfLifeKataTests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        //https://relishapp.com/ninjaneering/bdd-kata-conways-life/docs

        #region Evolving a dead cell
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
        [Test]
        public void ADeadCellWith4NeighboursStaysDead()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 0), new Cell(0, 1), new Cell(0, 2), new Cell(1, 2) });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }
        [Test]
        public void ADeadCellWith5NeighboursStaysDead()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 0), new Cell(0, 1), new Cell(0, 2), new Cell(1, 0), new Cell(1, 2) });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }
        [Test]
        public void ADeadCellWith6NeighboursStaysDead()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 0), new Cell(0, 1), new Cell(0, 2), new Cell(1, 0), new Cell(1, 2), new Cell(0, 2) });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }
        [Test]
        public void ADeadCellWith7NeighboursStaysDead()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 0), new Cell(0, 1), new Cell(0, 2), new Cell(1, 0), new Cell(1, 2), new Cell(0, 2), new Cell(1, 2) });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }
        [Test]
        public void ADeadCellWith8NeighboursStaysDead()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 0), new Cell(0, 1), new Cell(0, 2), new Cell(1, 0), new Cell(1, 2), new Cell(0, 2), new Cell(1, 2), new Cell(2, 2) });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }

        #endregion

        #region Evolving a living cell

        [Test]
        public void ALivingCellWith0NeighboursDies()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell>{new Cell(1,1)});
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }
        [Test]
        public void ALivingCellWith1NeighbourDies()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 1) ,new Cell(1, 1) });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }
        [Test]
        public void ALivingCellWith2NeighboursLives()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 1) , new Cell(1, 1), new Cell(1, 2) });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.True);
        }
        [Test]
        public void ALivingCellWith3NeighboursLives()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 0), new Cell(0, 1), new Cell(0, 2), new Cell(1, 1)});
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.True);
        }
        [Test]
        public void ALivingCellWith4NeighboursDies()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 0), new Cell(0, 1), new Cell(0, 2), new Cell(1, 1), new Cell(1, 2) });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }
        [Test]
        public void ALivingCellWith5NeighboursDies()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 0), new Cell(0, 1), new Cell(0, 2), new Cell(1, 0), new Cell(1, 1), new Cell(1, 2) });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }
        [Test]
        public void ALivingCellWith6NeighboursDies()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 0), new Cell(0, 1), new Cell(0, 2), new Cell(1, 0), new Cell(1, 1), new Cell(1, 2), new Cell(2, 0) });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }
        [Test]
        public void ALivingCellWith7NeighboursDies()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 0), new Cell(0, 1), new Cell(0, 2), new Cell(1, 0), new Cell(1, 1), new Cell(1, 2), new Cell(2, 0), new Cell(2, 1) });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }
        [Test]
        public void ALivingCellWith8NeighboursDies()
        {
            var intitialGeneration = new Generation(3, 3, new List<Cell> { new Cell(0, 0), new Cell(0, 1), new Cell(0, 2), new Cell(1, 0), new Cell(1, 1), new Cell(1, 2), new Cell(2, 0), new Cell(2, 1), new Cell(2,2) });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.IsCellAlive(1, 1), Is.False);
        }
        #endregion

        #region EvolvingMultipleLivingCells

        [Test]
        public void ASparseGridWithNobodyStayingAlive()
        {
            var intitialGeneration = new Generation(5, 5, 
                new List<Cell> {new Cell(1, 1), new Cell(1, 3),
                new Cell(3, 1), new Cell(3, 3)});

            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.CellsMatchGeneration(new List<Cell>
            {
                new Cell(0, 0, false),
                new Cell(0, 1, false),
                new Cell(0, 2, false),
                new Cell(0, 3, false),
                new Cell(0, 4, false),
                new Cell(1, 0, false),
                new Cell(1, 1, false),
                new Cell(1, 2, false),
                new Cell(1, 3, false),
                new Cell(1, 4, false),
                new Cell(2, 0, false),
                new Cell(2, 1, false),
                new Cell(2, 2, false),
                new Cell(2, 3, false),
                new Cell(2, 4, false),
                new Cell(3, 0, false),
                new Cell(3, 1, false),
                new Cell(3, 2, false),
                new Cell(3, 3, false),
                new Cell(3, 4, false),
                new Cell(4, 0, false),
                new Cell(4, 1, false),
                new Cell(4, 2, false),
                new Cell(4, 3, false),
                new Cell(4, 4, false)
            }), Is.True);
        }

        [Test]
        public void AnOverCrowdedGrid()
        {
            var intitialGeneration = new Generation(5, 5, new List<Cell>
            {
                new Cell(1, 1), new Cell(1, 2), new Cell(1, 3),
                new Cell(2, 1), new Cell(2, 2), new Cell(2, 3),
                new Cell(3, 1), new Cell(3, 2), new Cell(3, 3)
            });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.CellsMatchGeneration(new List<Cell>
            {
                new Cell(0, 0, false),
                new Cell(0, 1, false),
                new Cell(0, 2),
                new Cell(0, 3, false),
                new Cell(0, 4, false),
                new Cell(1, 0, false),
                new Cell(1, 1),
                new Cell(1, 2, false),
                new Cell(1, 3),
                new Cell(1, 4, false),
                new Cell(2, 0),
                new Cell(2, 1, false),
                new Cell(2, 2, false),
                new Cell(2, 3,false),
                new Cell(2, 4),
                new Cell(3, 0, false),
                new Cell(3, 1),
                new Cell(3, 2, false),
                new Cell(3, 3),
                new Cell(3, 4, false),
                new Cell(4, 0, false),
                new Cell(4, 1, false),
                new Cell(4, 2),
                new Cell(4, 3, false),
                new Cell(4, 4, false)
            }), Is.True);
        }

        [Test]
        public void AReallyOverCrowdedGrid()
        {
            var intitialGeneration = new Generation(5, 5, new List<Cell>
            {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(0, 2),
                new Cell(0, 3),
                new Cell(0, 4),
                new Cell(1, 0),
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(1, 3),
                new Cell(1, 4),
                new Cell(2, 0),
                new Cell(2, 1),
                new Cell(2, 2),
                new Cell(2, 3),
                new Cell(2, 4),
                new Cell(3, 0),
                new Cell(3, 1),
                new Cell(3, 2),
                new Cell(3, 3),
                new Cell(3, 4),
                new Cell(4, 0),
                new Cell(4, 1),
                new Cell(4, 2),
                new Cell(4, 3),
                new Cell(4, 4)
            });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.CellsMatchGeneration(new List<Cell>
            {
                new Cell(0, 0),
                new Cell(0, 1, false),
                new Cell(0, 2, false),
                new Cell(0, 3, false),
                new Cell(0, 4),
                new Cell(1, 0, false),
                new Cell(1, 1, false),
                new Cell(1, 2, false),
                new Cell(1, 3, false),
                new Cell(1, 4, false),
                new Cell(2, 0, false),
                new Cell(2, 1, false),
                new Cell(2, 2, false),
                new Cell(2, 3,false),
                new Cell(2, 4, false),
                new Cell(3, 0, false),
                new Cell(3, 1, false),
                new Cell(3, 2, false),
                new Cell(3, 3, false),
                new Cell(3, 4, false),
                new Cell(4, 0),
                new Cell(4, 1, false),
                new Cell(4, 2, false),
                new Cell(4, 3, false),
                new Cell(4, 4)
            }), Is.True);

            world.Evolve();
            Assert.That(world.CellsMatchGeneration(new List<Cell>
            {
                new Cell(0, 0, false),
                new Cell(0, 1, false),
                new Cell(0, 2, false),
                new Cell(0, 3, false),
                new Cell(0, 4, false),
                new Cell(1, 0, false),
                new Cell(1, 1, false),
                new Cell(1, 2, false),
                new Cell(1, 3, false),
                new Cell(1, 4, false),
                new Cell(2, 0, false),
                new Cell(2, 1, false),
                new Cell(2, 2, false),
                new Cell(2, 3,false),
                new Cell(2, 4, false),
                new Cell(3, 0, false),
                new Cell(3, 1, false),
                new Cell(3, 2, false),
                new Cell(3, 3, false),
                new Cell(3, 4, false),
                new Cell(4, 0, false),
                new Cell(4, 1, false),
                new Cell(4, 2, false),
                new Cell(4, 3, false),
                new Cell(4, 4, false)
            }), Is.True);
        }

        [Test]
        public void MultipleDeadCellsComingToLife()
        {
            //Blinker
            var intitialGeneration = new Generation(5, 5, new List<Cell>
            {
                new Cell(2, 1), new Cell(2, 2), new Cell(2, 3)
            });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.CellsMatchGeneration(new List<Cell>
            {
                new Cell(0, 0, false),
                new Cell(0, 1, false),
                new Cell(0, 2, false),
                new Cell(0, 3, false),
                new Cell(0, 4, false),
                new Cell(1, 0, false),
                new Cell(1, 1, false),
                new Cell(1, 2),
                new Cell(1, 3, false),
                new Cell(1, 4, false),
                new Cell(2, 0, false),
                new Cell(2, 1, false),
                new Cell(2, 2),
                new Cell(2, 3, false),
                new Cell(2, 4, false),
                new Cell(3, 0, false),
                new Cell(3, 1, false),
                new Cell(3, 2),
                new Cell(3, 3, false),
                new Cell(3, 4, false),
                new Cell(4, 0, false),
                new Cell(4, 1, false),
                new Cell(4, 2, false),
                new Cell(4, 3, false),
                new Cell(4, 4, false)
            }), Is.True);
        }

        #endregion

        #region Evolving multiple times
        [Test]
        public void CellsComeAliveThenDieOff()
        {
            var intitialGeneration = new Generation(5, 5, new List<Cell>
            {
                new Cell(2, 1), new Cell(2, 2), new Cell(2, 3)
            });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.CellsMatchGeneration(new List<Cell>
            {
                new Cell(0, 0, false),
                new Cell(0, 1, false),
                new Cell(0, 2, false),
                new Cell(0, 3, false),
                new Cell(0, 4, false),
                new Cell(1, 0, false),
                new Cell(1, 1, false),
                new Cell(1, 2),
                new Cell(1, 3, false),
                new Cell(1, 4, false),
                new Cell(2, 0, false),
                new Cell(2, 1, false),
                new Cell(2, 2),
                new Cell(2, 3,false),
                new Cell(2, 4, false),
                new Cell(3, 0, false),
                new Cell(3, 1, false),
                new Cell(3, 2),
                new Cell(3, 3, false),
                new Cell(3, 4, false),
                new Cell(4, 0, false),
                new Cell(4, 1, false),
                new Cell(4, 2, false),
                new Cell(4, 3, false),
                new Cell(4, 4, false)
            }), Is.True);

            world.Evolve();
            Assert.That(world.CellsMatchGeneration(new List<Cell>
            {
                new Cell(0, 0, false),
                new Cell(0, 1, false),
                new Cell(0, 2, false),
                new Cell(0, 3, false),
                new Cell(0, 4, false),
                new Cell(1, 0, false),
                new Cell(1, 1, false),
                new Cell(1, 2, false),
                new Cell(1, 3, false),
                new Cell(1, 4, false),
                new Cell(2, 0, false),
                new Cell(2, 1),
                new Cell(2, 2),
                new Cell(2, 3),
                new Cell(2, 4, false),
                new Cell(3, 0, false),
                new Cell(3, 1, false),
                new Cell(3, 2, false),
                new Cell(3, 3, false),
                new Cell(3, 4, false),
                new Cell(4, 0, false),
                new Cell(4, 1, false),
                new Cell(4, 2, false),
                new Cell(4, 3, false),
                new Cell(4, 4, false)
            }), Is.True);
        }
        #endregion

        #region Static Generations
        [Test]
        public void Block()
        {
            var intitialGeneration = new Generation(5, 5, new List<Cell>
            {
                new Cell(1, 1), new Cell(1, 2),
                new Cell(2, 1), new Cell(2, 2)
            });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.CellsMatchGeneration(new List<Cell>
            {
                new Cell(0, 0, false),
                new Cell(0, 1, false),
                new Cell(0, 2, false),
                new Cell(0, 3, false),
                new Cell(0, 4, false),
                new Cell(1, 0, false),
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(1, 3, false),
                new Cell(1, 4, false),
                new Cell(2, 0, false),
                new Cell(2, 1),
                new Cell(2, 2),
                new Cell(2, 3,false),
                new Cell(2, 4, false),
                new Cell(3, 0, false),
                new Cell(3, 1, false),
                new Cell(3, 2, false),
                new Cell(3, 3, false),
                new Cell(3, 4, false),
                new Cell(4, 0, false),
                new Cell(4, 1, false),
                new Cell(4, 2, false),
                new Cell(4, 3, false),
                new Cell(4, 4, false)
            }), Is.True);
        }

        [Test]
        public void Beehive()
        {
            var intitialGeneration = new Generation(5, 5, new List<Cell>
            {
                new Cell(1, 2), new Cell(1, 3),
                new Cell(2, 1), new Cell(2, 4),
                new Cell(3, 2), new Cell(3, 3)
            });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.CellsMatchGeneration(new List<Cell>
            {
                new Cell(0, 0, false),
                new Cell(0, 1, false),
                new Cell(0, 2, false),
                new Cell(0, 3, false),
                new Cell(0, 4, false),
                new Cell(1, 0, false),
                new Cell(1, 1, false),
                new Cell(1, 2),
                new Cell(1, 3),
                new Cell(1, 4, false),
                new Cell(2, 0, false),
                new Cell(2, 1),
                new Cell(2, 2, false),
                new Cell(2, 3,false),
                new Cell(2, 4),
                new Cell(3, 0, false),
                new Cell(3, 1, false),
                new Cell(3, 2),
                new Cell(3, 3),
                new Cell(3, 4, false),
                new Cell(4, 0, false),
                new Cell(4, 1, false),
                new Cell(4, 2, false),
                new Cell(4, 3, false),
                new Cell(4, 4, false)
            }), Is.True);
        }

        [Test]
        public void Loaf()
        {
            var intitialGeneration = new Generation(5, 5, new List<Cell>
            {
                new Cell(1, 2), new Cell(1, 3),
                new Cell(2, 1), new Cell(2, 4),
                new Cell(3, 2), new Cell(3, 4),
                new Cell(4, 3)
            });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.CellsMatchGeneration(new List<Cell>
            {
                new Cell(0, 0, false),
                new Cell(0, 1, false),
                new Cell(0, 2, false),
                new Cell(0, 3, false),
                new Cell(0, 4, false),
                new Cell(1, 0, false),
                new Cell(1, 1, false),
                new Cell(1, 2),
                new Cell(1, 3),
                new Cell(1, 4, false),
                new Cell(2, 0, false),
                new Cell(2, 1),
                new Cell(2, 2, false),
                new Cell(2, 3,false),
                new Cell(2, 4),
                new Cell(3, 0, false),
                new Cell(3, 1, false),
                new Cell(3, 2),
                new Cell(3, 3, false),
                new Cell(3, 4),
                new Cell(4, 0, false),
                new Cell(4, 1, false),
                new Cell(4, 2, false),
                new Cell(4, 3),
                new Cell(4, 4, false)
            }), Is.True);
        }

        [Test]
        public void Boat()
        {
            var intitialGeneration = new Generation(5, 5, new List<Cell>
            {
                new Cell(1, 1), new Cell(1, 2),
                new Cell(2, 1), new Cell(2, 3),
                new Cell(3, 2)
            });
            var world = new World(intitialGeneration);
            world.Evolve();
            Assert.That(world.CellsMatchGeneration(new List<Cell>
            {
                new Cell(0, 0, false),
                new Cell(0, 1, false),
                new Cell(0, 2, false),
                new Cell(0, 3, false),
                new Cell(0, 4, false),
                new Cell(1, 0, false),
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(1, 3, false),
                new Cell(1, 4, false),
                new Cell(2, 0, false),
                new Cell(2, 1),
                new Cell(2, 2, false),
                new Cell(2, 3),
                new Cell(2, 4, false),
                new Cell(3, 0, false),
                new Cell(3, 1, false),
                new Cell(3, 2),
                new Cell(3, 3, false),
                new Cell(3, 4, false),
                new Cell(4, 0, false),
                new Cell(4, 1, false),
                new Cell(4, 2, false),
                new Cell(4, 3, false),
                new Cell(4, 4, false)
            }), Is.True);
        }
        #endregion
    }
}
