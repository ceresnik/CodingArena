using CodingArena.Player;
using CodingArena.Player.Battlefield;

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
        public int MaxHP => BattleBot.MaxHP;
        public int HP => BattleBot.HP;
        public int MaxSP => BattleBot.MaxSP;
        public int SP => BattleBot.SP;
        public int MaxEP => BattleBot.MaxEP;
        public int EP => BattleBot.EP;
        public IBattlefieldPlace Position => BattleBot.Position;
        public double DistanceTo(IEnemy enemy) => BattleBot.DistanceTo(enemy);
        public override string ToString() => Name;
    }
}