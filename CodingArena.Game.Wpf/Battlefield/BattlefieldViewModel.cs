using CodingArena.Game.Entities;
using CodingArena.Game.Wpf.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodingArena.Game.Wpf.Battlefield
{
    internal class BattlefieldViewModel : ViewModel
    {
        public BattlefieldViewModel(IEnumerable<IBattleBot> bots)
        {
            Bots = new ObservableCollection<BattlefieldBotViewModel>();
            foreach (var bot in bots)
            {
                Bots.Add(new BattlefieldBotViewModel(bot));
            }
        }

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