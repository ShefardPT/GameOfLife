using GameOfLife.Core.Models;
using GameOfLife.Engine.Interfaces;
using GameOfLife.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GameOfLife.Engine
{
    public class AppEngine
    {
        public void Run()
        {
            var field = new CellField(20, 20);
            field.SeedFieldRandomly(0.3);
            IEnviroment env = new ClassicEnviroment();

            // отрисовать первичную картину

            for (int i = 0; i < 600; i++)
            {
                env.GenerateNextState(field);

                // отрисовать картну

                Thread.Sleep(1000);
            }
        }
    }
}
