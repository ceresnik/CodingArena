using System.Collections.Generic;
using CodingArena.Player.Battlefield;
using CodingArena.Player.TurnActions;

namespace CodingArena.Player.Implement
{
    public interface IBotAI
    {
        ITurnAction CreateTurnAction(IBotState botState, IEnumerable<IEnemy> enemies, IBattlefield battlefield);
    }
}