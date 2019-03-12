using CodingArena.Game.Entities;
using CodingArena.Game.Wpf.Common;
using System.Collections.ObjectModel;

namespace CodingArena.Game.Wpf.Battlefield
{
    internal class BattlefieldViewModel : ViewModel
    {
        public BattlefieldViewModel(IRound round)
        {
            BattlefieldHeight = 1000;
            BattlefieldWidth = 1000;
            Bots = new ObservableCollection<BattlefieldBotViewModel>();
            foreach (var bot in round.Bots)
            {
                Bots.Add(new BattlefieldBotViewModel(bot, BattlefieldWidth, BattlefieldHeight, round.Battlefield));
            }
        }

        public int BattlefieldHeight { get; }

        public int BattlefieldWidth { get; }

        public ObservableCollection<BattlefieldBotViewModel> Bots { get; }

        public void Update(IBattleBot bot)
        {
            foreach (var botViewModel in Bots)
            {
                if (botViewModel.BotName == bot.Name)
                {
                    botViewModel.UpdateFrom(bot);
                }
            }
        }
    }
}