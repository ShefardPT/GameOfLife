using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Core.Models
{
    public class Cell
    {
        public bool IsAlive { get; set; }
        public int PosX { get; }
        public int PosY { get; }

        public Cell(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }

        public Cell(int posX, int posY, bool isAlive)
        {
            PosX = posX;
            PosY = posY;
            IsAlive = isAlive;
        }

        public bool Equals(Cell cell)
        {
            if (this.IsAlive != cell.IsAlive ||
                this.PosX != cell.PosX ||
                this.PosY != cell.PosY)
                return false;

            return true;
        }

        public override string ToString()
        {
            var state = IsAlive ? "Alive" : "Dead";
            return $"{state} : [{PosX}:{PosY}]";
        }
    }
}
