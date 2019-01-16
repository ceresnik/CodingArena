using System.Threading.Tasks;

namespace CodingArena.Player.TurnActions
{
    public interface ITurnAction
    {
        Task ExecuteAsync();
    }
}