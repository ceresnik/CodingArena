using CodingArena.Player;

namespace CodingArena.Game
{
    internal class Enemy : Robot, IEnemy
    {
        public Enemy(string name, int maxHP, int hp, int maxSP, int sp) : base(name, maxHP, hp, maxSP, sp)
        {
        }
    }
}