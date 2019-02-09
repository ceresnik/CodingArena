using CodingArena.Game.Entities;

namespace CodingArena.Game.Wpf
{
    internal class BotStateViewModel
    {
        public IBattleBot BattleBot { get; }

        public BotStateViewModel(IBattleBot battleBot)
        {
            BattleBot = battleBot;
        }

        public string BotName => BattleBot.Name;

        public string Action => BattleBot.Action;

        public int MaxHP => BattleBot.MaxHP;

        public int HP => BattleBot.HP;

        public int MaxSP => BattleBot.MaxSP;

        public int SP => BattleBot.SP;

        public int MaxEP => BattleBot.MaxEP;

        public int EP => BattleBot.EP;
    }
}