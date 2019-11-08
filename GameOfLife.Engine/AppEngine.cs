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
            var field = new CellField(40, 40);
            field.SeedFieldRandomly(0.2);
            IEnviroment env = new ClassicEnviroment();

            using (var coeAdapter = new ConsoleOutputEngineAdapter())
            {
                coeAdapter.Render(field);

                for (int i = 0; i < 600; i++)
                {
                    env.GenerateNextState(field);
                    coeAdapter.Render(field);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
