using GameOfLife.Core.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class EqualsTests
    {
        [Test]
        public void Should_Cell_Equals()
        {
            var cell1 = new Cell(0, 0);
            var cell2 = new Cell(0, 0);

            Assert.IsTrue(cell1.Equals(cell2));
            Assert.IsFalse(cell1 == cell2);
        }

        [Test]
        public void Should_CellField_Equals()
        {
            var cellField1 = new CellField(2, 2);
            cellField1.SeedLife(0, 0);
            var cellField2 = new CellField(2, 2);
            cellField2.SeedLife(0, 0);

            Assert.IsTrue(cellField1.Equals(cellField2));
            Assert.IsFalse(cellField1 == cellField2);
        }
    }
}
