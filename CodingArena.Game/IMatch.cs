using System.Threading.Tasks;

namespace CodingArena.Game
{
    public interface IMatch
    {
        Task<IRound> CreateRoundAsync();
        Task WaitForNextRoundAsync();
        void Process(RoundResult roundResult);
    }
}