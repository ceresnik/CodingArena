using CodingArena.Player;
using CodingArena.Player.Battlefield;

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
        public int HP => BattleBot.HP;
        public int SP => BattleBot.SP;
        public IBattlefieldPlace Position => BattleBot.Position;
        public double DistanceTo(IEnemy enemy) => BattleBot.DistanceTo(enemy);
        public override string ToString() => Name;
    }
}