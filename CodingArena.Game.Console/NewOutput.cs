using System.ComponentModel.Composition;
using static System.Console;

namespace CodingArena.Game.Console
{
    [Export(typeof(INewOutput))]
    internal class NewOutput : INewOutput
    {
        private IMatchNotifier Match { get; set; }

        public void Observe(IGameNotifier gameNotifier) =>
            gameNotifier.Started += (sender, args) =>
        {
            WriteLine("CodingArena");
            Match = args.MatchNotifier;
        };
    }
}