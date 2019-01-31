using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace CodingArena.Game
{
    [Export(typeof(IMatch))]
    internal class Match : IMatch
    {
        [ImportingConstructor]
        public Match(IOutput output, ISettings settings, IBotFactory botFactory, IBattlefieldFactory battlefieldFactory)
        {
            Output = output ?? throw new ArgumentNullException(nameof(output));
            Settings = settings;
            BotFactory = botFactory;
            BattlefieldFactory = battlefieldFactory;
            Winners = new Dictionary<string, int>();
        }

        private Dictionary<string, int> Winners { get; }
        private IOutput Output { get; }
        private ISettings Settings { get; }
        private IBotFactory BotFactory { get; }
        private IBattlefieldFactory BattlefieldFactory { get; }

        public IRound CreateRound()
        {
            var battlefield = BattlefieldFactory.Create();
            Output.SetBattlefield(battlefield);
            var bots = BotFactory.CreateBots(battlefield).ToList();
            return new Round(Output, Settings, battlefield, bots);
        }

        public Task WaitForNextRoundAsync()
        {
            Output.NextRoundIn(Settings.NextRoundDelay);
            return Task.Delay(Settings.NextRoundDelay);
        }

        public void Process(RoundResult roundResult)
        {
            if (roundResult.WinnerName == null)
            {
                return;
            }
            if (Winners.ContainsKey(roundResult.WinnerName))
            {
                Winners[roundResult.WinnerName]++;
            }
            else
            {
                Winners.Add(roundResult.WinnerName, 1);
            }
            Output.MatchResult(Winners);
        }
    }
}