using System.ComponentModel.Composition;
using static System.Console;

namespace CodingArena.Game.Tests.Doubles
{
    [Export(typeof(IOutput))]
    internal class Output : IOutput
    {
        public void Set(IMatch match)
        {
        }

        public void Set(IRound round)
        {
        }

        public void Set(ITurn turn)
        {
        }

        public void Update()
        {
        }

        public void Error(string message) => WriteLine($"Error: {message}");
    }
}