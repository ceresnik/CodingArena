using System.Threading.Tasks;

namespace CodingArena.Game.Console
{
    public interface IMatch
    {
        IRound CreateRound();
        Task WaitForNextRoundAsync();
        void Process(RoundResult roundResult);
    }
}