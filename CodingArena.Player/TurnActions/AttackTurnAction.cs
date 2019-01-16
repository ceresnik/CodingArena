using System.Threading.Tasks;

namespace CodingArena.Player.TurnActions
{
    public class AttackTurnAction : ITurnAction
    {
        public Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}