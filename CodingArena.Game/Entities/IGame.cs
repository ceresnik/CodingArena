using System;
using System.Threading.Tasks;

namespace CodingArena.Game.Entities
{
    public interface IGame
    {
        Task StartAsync();
        IMatch Match { get; }
        event EventHandler MatchStarting;
        event EventHandler MatchFinished;
    }
}