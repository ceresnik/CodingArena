using CodingArena.Game.Entities;
using System.Collections.ObjectModel;

namespace CodingArena.Game.Wpf
{
    internal interface IMainViewModel : IViewModel
    {
        void Show();
        IGame Game { get; set; }
        string MatchText { get; set; }
        int RoundNumber { get; set; }
        int MaxRounds { get; set; }
        int BattlefieldWidth { get; set; }
        int BattlefieldHeight { get; set; }
        string BattlefieldText { get; set; }
        int TurnNumber { get; set; }
        int MaxTurns { get; set; }
        string TurnText { get; set; }
        string NextRoundIn { get; set; }
        ObservableCollection<BattlefieldBotViewModel> BattlefieldBots { get; }
    }

    internal class BattlefieldBotViewModel
    {
        public BattlefieldBotViewModel(IBattleBot battleBot)
        {
            BotName = battleBot.Name;
            X = battleBot.Position.X * 10;
            Y = 500 - battleBot.Position.Y * 10 - 10;
        }

        public string BotName { get; }
        public int X { get; }
        public int Y { get; }
    }
}