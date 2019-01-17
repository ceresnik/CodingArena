using System.Threading.Tasks;

namespace CodingArena.Player.TurnActions
{
    public sealed class RechargeShield : ITurnAction
    {
        public Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}