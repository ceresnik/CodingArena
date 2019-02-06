using System.Collections.Generic;

namespace CodingArena.Game
{
    public interface IOutput
    {
        void Set(IMatch match);
        void Set(IRound round);
        void Set(ITurn turn);
        void Update();
        void Error(string message);
    }
}