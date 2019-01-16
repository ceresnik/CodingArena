using System.Threading.Tasks;

namespace CodingArena.Player.TurnActions
{
    public class MoveTurnAction : ITurnAction
    {
        public Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}