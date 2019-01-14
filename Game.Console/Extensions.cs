using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Console
{
    internal static class Extensions
    {
        public static void OnEmpty<T>(this IEnumerable<T> enumerable, Action action) where T : class
        {
            if (enumerable.Any() == false) action();
        }
    }
}