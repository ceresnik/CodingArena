using CodingArena.Game.Entities;

namespace CodingArena.Game.Wpf
{
    internal class BattlefieldBotViewModel
    {
        public BattlefieldBotViewModel(IBattleBot battleBot)
        {
            BotName = battleBot.Name;
            X = battleBot.Position.X * 14;
            Y = 700 - battleBot.Position.Y * 14 - 14;
        }

        public string BotName { get; }
        public int X { get; }
        public int Y { get; }
    }
}