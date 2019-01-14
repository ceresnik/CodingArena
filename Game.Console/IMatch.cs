using System.Threading.Tasks;

namespace Game.Console
{
    internal interface IMatch
    {
        Task<IRound> CreateRoundAsync();
        Task WaitForNextRoundAsync();
    }
}