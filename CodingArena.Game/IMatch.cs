using System.Threading.Tasks;

namespace CodingArena.Game
{
    internal interface IMatch
    {
        Task<IRound> CreateRoundAsync();
        Task WaitForNextRoundAsync();
    }
}