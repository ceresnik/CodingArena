using CodingArena.Game.Entities;
using CodingArena.Player;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game.Internal
{
    internal class InsideView : IOwnBot, IHealth, IShield, IEnergy
    {
        private IBattleBot BattleBot { get; }

        public InsideView(IBattleBot battleBot)
        {
            BattleBot = battleBot;
        }

        public string Name => BattleBot.Name;
        public IHealth Health => this;
        public IShield Shield => this;
        public IEnergy Energy => this;
        public IBattlefieldPlace Position => BattleBot.Position;
        int IHealth.Maximum => BattleBot.MaxHP;
        int IHealth.Actual => BattleBot.HP;
        int IHealth.Percent => BattleBot.HP * 100 / BattleBot.MaxHP;
        int IShield.Maximum => BattleBot.MaxSP;
        int IShield.Actual => BattleBot.SP;
        int IShield.Percent => BattleBot.SP * 100 / BattleBot.MaxSP;
        int IEnergy.Maximum => BattleBot.MaxEP;
        int IEnergy.Actual => BattleBot.EP;
        int IEnergy.Percent => BattleBot.EP * 100 / BattleBot.MaxEP;
        public double DistanceTo(IEnemy enemy) => BattleBot.DistanceTo(enemy);
        public override string ToString() => Name;
    }
}