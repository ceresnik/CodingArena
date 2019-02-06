using CodingArena.Player;

namespace CodingArena.Game.Internal
{
    internal class InsideView : IOwnBot
    {
        private IBattleBot BattleBot { get; }

        public InsideView(IBattleBot battleBot)
        {
            BattleBot = battleBot;
        }

        public string Name => BattleBot.Name;
        public float Damage => 100 - BattleBot.HP * 100 / (float)BattleBot.MaxHP;
        public float Shield => BattleBot.SP * 100 / (float)BattleBot.MaxSP;
        public float Energy => BattleBot.EP * 100 / (float) BattleBot.MaxEP;
        public override string ToString() => Name;
    }
}