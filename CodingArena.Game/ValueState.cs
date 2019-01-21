using System;

namespace CodingArena.Game
{
    internal class ValueState
    {
        public ValueState(int max)
            :this(max, max)
        {
        }

        public ValueState(int actual, int max)
        {
            if (actual < 0) throw new ArgumentOutOfRangeException(
                nameof(actual), actual, "Value is less than 0.");
            if (max < 0) throw new ArgumentOutOfRangeException(
                nameof(max), max, "Value is less than 0.");
            if (actual > max) throw new ArgumentOutOfRangeException(
                nameof(actual), actual, $"{nameof(actual)} is greater than {nameof(max)}.");
            Max = max;
            Actual = actual;
        }

        public int Max { get; }

        public int Actual { get; }

        public double Percentage => Actual * 100 / (double) Max;
    }
}