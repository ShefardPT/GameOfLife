using GameOfLife.Engine;
using GameOfLife.Engine.Interfaces;
using GameOfLife.Core.Models;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class ClassicEnviromentTests
    {
        IEnviroment _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new ClassicEnviroment();
        }

        [Test]
        public void Should_state_not_changed_on_GenerateNextState()
        {
            var cellFieldInitial = new CellField(3, 3);
            var cellFieldWithNextState = new CellField(3, 3);

            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    cellFieldInitial.SeedLife(i, j);
                    cellFieldWithNextState.SeedLife(i, j);
                }
            }

            _sut.GenerateNextState(cellFieldWithNextState);
            Assert.That(cellFieldInitial.Equals(cellFieldWithNextState));
        }

        [Test]
        public void Should_kill_lone_cell_on_GenerateNextState()
        {
            var cellFieldInitial = new CellField(3, 3);
            cellFieldInitial.SeedLife(1, 1);

            _sut.GenerateNextState(cellFieldInitial);
            Assert.That(!cellFieldInitial[1, 1].IsAlive);
        }

        [Test]
        public void Should_kill_two_neighbour_cells_on_GenerateNextState()
        {
            var cellFieldInitial = new CellField(3, 3);
            cellFieldInitial.SeedLife(0, 0);
            cellFieldInitial.SeedLife(0, 1);

            _sut.GenerateNextState(cellFieldInitial);
            Assert.That(!cellFieldInitial[0, 0].IsAlive);
            Assert.That(!cellFieldInitial[0, 1].IsAlive);
        }

        [Test]
        public void Should_stay_alive_with_three_neighbours_on_GenerateNextState()
        {
            var cellFieldInitial = new CellField(3, 3);
            cellFieldInitial.SeedLife(1, 0);
            cellFieldInitial.SeedLife(0, 1);
            cellFieldInitial.SeedLife(1, 1);
            cellFieldInitial.SeedLife(2, 1);

            _sut.GenerateNextState(cellFieldInitial);
            Assert.That(cellFieldInitial[1, 1].IsAlive);
        }

        [Test]
        public void Should_reborn_with_three_neighbours_on_GenerateNextState()
        {
            var cellFieldInitial = new CellField(3, 3);
            cellFieldInitial.SeedLife(0, 0);
            cellFieldInitial.SeedLife(1, 0);
            cellFieldInitial.SeedLife(0, 1);

            _sut.GenerateNextState(cellFieldInitial);
            Assert.That(cellFieldInitial[1, 1].IsAlive);
        }

        [Test]
        public void Should_kill_with_four_neighbours_on_GenerateNextState()
        {
            var cellFieldInitial = new CellField(3, 3);
            cellFieldInitial.SeedLife(0, 0);
            cellFieldInitial.SeedLife(1, 0);
            cellFieldInitial.SeedLife(0, 1);
            cellFieldInitial.SeedLife(1, 1);
            cellFieldInitial.SeedLife(2, 0);

            _sut.GenerateNextState(cellFieldInitial);
            Assert.That(!cellFieldInitial[1, 1].IsAlive);
        }
    }
}