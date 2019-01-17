using System.Threading.Tasks;

namespace CodingArena.Player.TurnActions
{
    public sealed class Attack : ITurnAction
    {
        public Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}