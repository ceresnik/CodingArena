using CodingArena.Game.Entities;
using CodingArena.Game.Wpf.Battlefield;
using CodingArena.Game.Wpf.Common;
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
        BattlefieldViewModel BattlefieldViewModel { get; set; }
        ObservableCollection<BotStateViewModel> BotStates { get; }
        ObservableCollection<BotScoreViewModel> BotScores { get; }
        ObservableCollection<BotScoreViewModel> RoundBotScores { get; }
    }
}