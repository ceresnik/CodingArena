using System.Threading.Tasks;

namespace CodingArena.Player.TurnActions
{
    public class RechargeBattery : ITurnAction
    {
        public Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}