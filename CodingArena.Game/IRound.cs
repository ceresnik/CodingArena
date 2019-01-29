using System.Threading.Tasks;

namespace CodingArena.Game
{
    public interface IRound
    {
        Task<RoundResult> StartAsync();
    }
}