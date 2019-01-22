using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Game
{
    internal class Bot : IBattlefieldObject
    {
        public Bot(TextWriter output, IBotAI botAI, Battlefield battlefield)
        {
            Output = output;
            BotAI = botAI ?? throw new ArgumentNullException(nameof(botAI));
            Battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
            if (string.IsNullOrWhiteSpace(botAI.BotName))
                throw new ArgumentException($"{nameof(botAI)} does not define {nameof(botAI.BotName)}.");
            MaxHP = 1000;
            HP = MaxHP;
            MaxSP = 1000;
            SP = MaxSP;
            MaxEP = 1000;
            EP = MaxEP;
        }

        public string Name => BotAI.BotName;
        public float Damage => 100 - Health;
        public float Shield => SP / (float)MaxSP;
        public float Energy => EP / (float)MaxEP;
        public IBattlefieldPlace Position => Battlefield[this];
        private TextWriter Output { get; }
        private IBotAI BotAI { get; }
        private Battlefield Battlefield { get; }
        private int MaxHP { get; set; }
        private int HP { get; set; }
        private float Health => HP / (float) MaxHP;
        private int MaxSP { get; set; }
        private int SP { get; set; }
        private int MaxEP { get; set; }
        private int EP { get; set; }
        private IOwnBot InsideView => new OwnBot(this);
        private IEnemy OutsideView => new Enemy(this);

        public void ExecuteTurnAction(IReadOnlyCollection<Bot> enemies, Battlefield battlefield)
        {
            var turnAction = BotAI.TurnAction(InsideView, enemies.Select(e => e.OutsideView).ToList(), battlefield);
            if (turnAction is MoveTurnAction move)
            {
                ExecuteMoveTurnAction(move, battlefield);
            }

            if (turnAction is AttackTurnAction attack)
            {
                ExecuteAttackTurnAction(attack, enemies);
            }

            if (turnAction is IdleTurnAction)
            {
                Output.WriteLine($"{Name} is idle.");
            }
        }

        private void ExecuteMoveTurnAction(MoveTurnAction move, Battlefield battlefield)
        {
            if (move.Direction == Direction.None)
            {
                Output.WriteLine($"{Name} doesn't move.");
                return;
            }

            int newX = Position.X;
            int newY = Position.Y;

            if (move.Direction == Direction.West && Position.X > 0)
                newX = Position.X - 1;
            if (move.Direction == Direction.East && Position.X < Battlefield.Size.Width - 1)
                newX = Position.X + 1;
            if (move.Direction == Direction.North && Position.Y < Battlefield.Size.Height - 1)
                newY = Position.Y + 1;
            if (move.Direction == Direction.South && Position.Y > 0)
                newY = Position.Y - 1;

            const int energyCost = 1;
            if (EP < energyCost)
            {
                Output.WriteLine($"{Name} doesn't have enough energy to move.");
                return;
            }
            if (battlefield.Move(this, newX, newY))
            {
                EP -= energyCost;
                Output.WriteLine($"{Name} moved {move.Direction}.");
            }
            else
            {
                Output.WriteLine($"{Name} cannot move {move.Direction}.");
            }
        }

        private void ExecuteAttackTurnAction(AttackTurnAction attack, IReadOnlyCollection<Bot> enemies)
        {
            var target = enemies.FirstOrDefault(e => e.Name == attack.Target.Name);
            if (target == null)
            {
                Output.WriteLine($"{Name} cannot attack {attack.Target.Name}.");
                return;
            }

            var distance = Position.DistanceTo(target.Position);
            const int maxRange = 10;
            if (distance > 10)
            {
                Output.WriteLine($"{Name} cannot attack {target.Name}. Target is out of range.");
                return;
            }

            const int energyCost = 5;
            if (Energy < energyCost)
            {
                Output.WriteLine($"{Name} doesn't have enough energy to attack.");
                return;
            }

            double chance = (maxRange - distance + 1) / maxRange;
            const int maxDamage = 100;
            int damage = (int) (maxDamage * chance);

            EP -= energyCost;

            if (damage <= 0)
            {
                Output.WriteLine($"{Name} attacks {target.Name} with no damage.");
            }
            else
            {
                target.TakeDamage(damage);
                Output.WriteLine($"{Name} attacks {target.Name} with {damage} damage.");
                if (target.HP <= 0)
                {
                    Output.WriteLine($"{target.Name} explodes.");
                }
            }
        }

        private void TakeDamage(int damage)
        {
            if (SP >= damage)
            {
                SP -= damage;
                return;
            }

            if (SP < damage && SP > 0)
            {
                HP -= damage - SP;
                SP = 0;
                return;
            }

            if (SP <= 0)
            {
                HP -= damage;
            }
        }
    }
}