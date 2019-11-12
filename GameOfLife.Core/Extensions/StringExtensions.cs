using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Core.Extensions
{
    public static class StringExtensions
    {
        public static string SanitizeStringToNumeral(this string text)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if ('0' < text[i] && text[i] < '9')
                    sb.Append(text[i]);
            }

            return sb.ToString();
        }
    }
}
