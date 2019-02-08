using System;
using System.Threading.Tasks;

namespace CodingArena.Game.Entities
{
    public interface IGame
    {
        void Start();
        Task StartAsync();
        IMatch Match { get; }
        event EventHandler MatchStarting;
        event EventHandler MatchFinished;
    }
}