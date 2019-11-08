using ConsoleOutputEngine.Core.Models;
using GameOfLife.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Engine
{
    public class ConsoleOutputEngineAdapter : IDisposable
    {
        private ConsoleOutputEngine.Engine _coe;

        public ConsoleOutputEngineAdapter()
        {
            _coe = new ConsoleOutputEngine.Engine();
        }

        public ConsoleOutputEngineAdapter(char whitePixelValue)
        {
            _coe = new ConsoleOutputEngine.Engine(whitePixelValue);
        }

        public void Render(CellField cellField)
        {
            var pixelMap = ParseToPixelMap(cellField);
            _coe.Render(pixelMap);
        }

        private IEnumerable<Pixel> ParseToPixelMap(CellField cellField)
        {
            for (int j = 0; j < cellField.Height; j++)
            {
                for (int i = 0; i < cellField.Width; i++)
                {
                    var cell = cellField[i, j];
                    if (cell.IsAlive)
                    {
                        yield return new Pixel(cell.PosX, cell.PosY, 'O');
                    }
                }
            }
        }

        public void Dispose()
        {
            _coe.Dispose();
        }
    }
}
