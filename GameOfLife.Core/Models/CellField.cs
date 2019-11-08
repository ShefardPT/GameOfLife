using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Core.Models
{
    public class CellField
    {
        private Cell[] _cells;
        public int Width { get; }
        public int Height { get; }
        public Cell this[int x, int y]
        {
            get
            {
                if (!IsIndexInRange(x, y))
                    throw new IndexOutOfRangeException();

                return _cells[Width * y + x];
            }
            private set
            {
                if (!IsIndexInRange(x, y))
                    throw new IndexOutOfRangeException();

                _cells[Width * y + x] = value;
            }
        }

        public CellField(int width, int height)
        {
            Width = width;
            Height = height;
            _cells = new Cell[width * height];

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    this[i, j] = new Cell(i, j);
                }
            }
        }

        public void SeedLife(int posX, int posY)
        {
            this[posX, posY].IsAlive = true;
        }
        public void SeedLife(Cell cell)
        {
            SeedLife(cell.PosX, cell.PosY);
        }
        public bool TrySeedLife(int posX, int posY)
        {
            try
            {
                SeedLife(posX, posY);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public bool TrySeedLife(Cell cell)
        {
            return TrySeedLife(cell.PosX, cell.PosY);
        }

        public void Kill(int posX, int posY)
        {
            this[posX, posY].IsAlive = false;
        }
        public void Kill(Cell cell)
        {
            Kill(cell.PosX, cell.PosY);
        }
        public bool TryKill(int posX, int posY)
        {
            try
            {
                Kill(posX, posY);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public bool TryKill(Cell cell)
        {
            return TryKill(cell.PosX, cell.PosY);
        }

        public IEnumerable<Cell> GetNeighbours(Cell cell)
        {
            var result = new List<Cell>();

            for (int j = cell.PosY - 1; j <= cell.PosY + 1; j++)
            {
                for (int i = cell.PosX - 1; i <= cell.PosX + 1; i++)
                {
                    if (cell.PosX == i && cell.PosY == j ||
                        !IsIndexInRange(i, j))
                        continue;

                    var neighbour = this[i, j];

                    result.Add(neighbour);
                }
            }

            return result;
        }

        private bool IsIndexInRange(int x, int y)
        {
            return !(x < 0 || y < 0) && x < Width && y < Height;
        }

        public bool Equals(CellField field)
        {
            if (this.Width != field.Width ||
                this.Height != field.Height)
                return false;

            for (int i = 0; i < this._cells.Length; i++)
            {
                if (!this._cells[i].Equals(field._cells[i]))
                    return false;
            }

            return true;
        }
    }
}
