using CodingArena.Player;

namespace CodingArena.Game.Internal
{
    internal class OutsideView : IEnemy
    {
        private IBattleBot BattleBot { get; }

        public OutsideView(IBattleBot battleBot)
        {
            BattleBot = battleBot;
        }

        public string Name => BattleBot.Name;
        public float Damage => 100 - BattleBot.HP * 100 / (float)BattleBot.MaxHP;
        public float Shield => BattleBot.SP * 100 / (float)BattleBot.MaxSP;

        public override string ToString() => Name;
    }
}