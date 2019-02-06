using System.Collections.Generic;

namespace CodingArena.Game
{
    public interface IOutput
    {
        void DisplayGameTitle();
        void Error(string message);
        void DisplayMatch(IEnumerable<Score> scores);
    }
}