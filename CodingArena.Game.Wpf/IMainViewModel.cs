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
        ObservableCollection<BotStateViewModel> BotStates { get; }
        ObservableCollection<BattlefieldBotViewModel> BattlefieldBots { get; }
        ObservableCollection<BotScoreViewModel> BotScores { get; }
    }
}