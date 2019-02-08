using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodingArena.Game.Entities
{
    public interface ITurn
    {
        int Number { get; }

        void Start(IEnumerable<IBattleBot> battleBots);

        Task StartAsync(IEnumerable<IBattleBot> battleBots);
    }
}