using GameOfLife.Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class CellFieldTests
    {
        private CellField _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new CellField(3, 3);
        }

        [Test]
        public void Should_get_neighbours_of_corner()
        {
            var cell = _sut[0, 0];

            var result = _sut.GetNeighbours(cell);

            Assert.That(result.Count() == 3);
            Assert.That(!result.Any(x => x.Equals(cell)));
        }

        [Test]
        public void Should_get_neighbours_of_center()
        {
            var cell = _sut[1, 1];

            var result = _sut.GetNeighbours(cell);

            Assert.That(result.Count() == 8);
            Assert.That(!result.Any(x => x.Equals(cell)));
        }
    }
}
