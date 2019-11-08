using GameOfLife.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Utilities
{
    public static class CellFieldSeeder
    {
        /// <summary>
        /// Seeds instance of CeedField with alive cells randomly
        /// </summary>
        /// <param name="field"></param>
        /// <param name="density">Value from 0 to 1. Defines the chance of seeding alive cell.</param>
        public static void SeedFieldRandomly(this CellField field, double density)
        {
            if (density < 0 || 1 < density)
                throw new ArgumentOutOfRangeException(nameof(density), density, "Value of the \"{0}\" should be in range of 0 and 1.");

            var random = new Random();

            for (int j = 0; j < field.Height; j++)
            {
                for (int i = 0; i < field.Width; i++)
                {
                    if (random.NextDouble() < density)
                        field.SeedLife(i, j);
                }
            }
        }
    }
}
