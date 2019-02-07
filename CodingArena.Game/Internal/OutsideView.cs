using CodingArena.Game.Entities;
using CodingArena.Player;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game.Internal
{
    internal class OutsideView : IEnemy, IHealth, IShield
    {
        private IBattleBot BattleBot { get; }

        public OutsideView(IBattleBot battleBot)
        {
            BattleBot = battleBot;
        }

        public string Name => BattleBot.Name;
        public IHealth Health => this;
        public IShield Shield => this;
        int IHealth.Maximum => BattleBot.MaxHP;
        int IHealth.Actual => BattleBot.HP;
        int IHealth.Percent => BattleBot.HP * 100 / BattleBot.MaxHP;
        int IShield.Maximum => BattleBot.MaxSP;
        int IShield.Actual => BattleBot.SP;
        int IShield.Percent => BattleBot.SP * 100 / BattleBot.MaxSP;
        public IBattlefieldPlace Position => BattleBot.Position;
        public double DistanceTo(IEnemy enemy) => BattleBot.DistanceTo(enemy);
        public override string ToString() => Name;
    }
}