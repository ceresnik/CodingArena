using System.Threading.Tasks;

namespace CodingArena.Game
{
    public interface IMatch
    {
        IRound CreateRound();
        Task WaitForNextRoundAsync();
        void Process(RoundResult roundResult);
    }
}