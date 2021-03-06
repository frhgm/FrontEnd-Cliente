﻿using System;

namespace CapaEntidades
{
    public static class Truncar
    {
        /// <summary>
        /// Get a substring of the first N characters.
        /// </summary>
        public static string Truncate(string source, int length)
        {
            if (source.Length > length)
            {
                source = source.Substring(0, length);
            }
            return source;
        }

        /// <summary>
        /// Get a substring of the first N characters. [Slow]
        /// </summary>
        public static string Truncate2(string source, int length)
        {
            return source.Substring(0, Math.Min(length, source.Length));
        }
    }
}