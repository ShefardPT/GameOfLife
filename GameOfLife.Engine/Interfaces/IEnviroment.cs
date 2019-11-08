using GameOfLife.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Engine.Interfaces
{
    public interface IEnviroment
    {
        void GenerateNextState(CellField field);
    }
}
