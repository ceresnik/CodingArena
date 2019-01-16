using System.Threading.Tasks;

namespace CodingArena.Player.TurnActions
{
    public class Attack : ITurnAction
    {
        public Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}