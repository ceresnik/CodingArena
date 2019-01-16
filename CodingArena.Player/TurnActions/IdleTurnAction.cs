using System.Threading.Tasks;

namespace CodingArena.Player.TurnActions
{
    public class IdleTurnAction : ITurnAction
    {
        public Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}