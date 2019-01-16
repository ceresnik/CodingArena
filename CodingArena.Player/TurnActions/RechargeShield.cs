using System.Threading.Tasks;

namespace CodingArena.Player.TurnActions
{
    public class RechargeShield : ITurnAction
    {
        public Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}