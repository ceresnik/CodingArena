using System.Threading.Tasks;

namespace CodingArena.Game.Console
{
    internal interface IMatch
    {
        Task<IRound> CreateRoundAsync();
        Task WaitForNextRoundAsync();
    }
}