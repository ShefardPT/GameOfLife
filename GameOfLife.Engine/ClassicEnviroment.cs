using System;
using System.Collections.Generic;
using System.Text;
using GameOfLife.Engine.Interfaces;
using GameOfLife.Core.Models;
using System.Linq;

namespace GameOfLife.Engine
{
    public class ClassicEnviroment : IEnviroment
    {
        private int _neighboursToReborn = 3;
        private int _neighboursToLiveMin = 2;
        private int _neighboursToLiveMax = 3;

        public void GenerateNextState(CellField field)
        {
            var changedCells = new List<Cell>();

            for (int j = 0; j < field.Height; j++)
            {
                for (int i = 0; i < field.Width; i++)
                {
                    var cell = field[i, j];
                    var neighboursAlive = field.GetNeighbours(cell).Count(x => x.IsAlive);

                    if (cell.IsAlive)
                    {
                        if (neighboursAlive < _neighboursToLiveMin)
                            changedCells.Add(new Cell(cell.PosX, cell.PosY, false));
                        else if (neighboursAlive > _neighboursToLiveMax)
                            changedCells.Add(new Cell(cell.PosX, cell.PosY, false));
                    }
                    else
                    {
                        if (neighboursAlive == _neighboursToReborn)
                            changedCells.Add(new Cell(cell.PosX, cell.PosY, true));
                    }
                }
            }

            foreach (var cell in changedCells)
            {
                field[cell.PosX, cell.PosY].IsAlive = cell.IsAlive;
            }
        }
    }
}
