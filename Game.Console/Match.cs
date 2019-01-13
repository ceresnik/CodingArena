using System.Threading.Tasks;
using static System.Console;

namespace Game.Console
{
    internal class Match : IMatch
    {
        public Task<IRound> StartMatchAsync()
        {
            WriteLine("Match started...");
            return Task.FromResult<IRound>(new Round());
        }
    }
}