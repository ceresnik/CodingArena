using System.Collections.Generic;
using System.Threading.Tasks;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;

namespace CodingArena.Game
{
    internal interface IRound
    {
        Task<RoundResult> StartRoundAsync(ICollection<IBot> bots, IBattlefield battlefield);
    }
}