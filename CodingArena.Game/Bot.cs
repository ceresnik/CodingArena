using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Game
{
    internal class Bot : IBattlefieldObject
    {
        public Bot(IOutput output, IBotAI botAI, Battlefield battlefield, GameConfiguration config)
        {
            Output = output;
            BotAI = botAI ?? throw new ArgumentNullException(nameof(botAI));
            Battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
            Config = config;
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
        public float Shield => SP * 100 / (float)MaxSP;
        public float Energy => EP * 100 / (float)MaxEP;
        public IBattlefieldPlace Position => Battlefield[this];
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public float Health => HP * 100 / (float) MaxHP;
        public int MaxSP { get; set; }
        public int SP { get; set; }
        public int MaxEP { get; set; }
        public int EP { get; set; }
        public IOwnBot InsideView => new OwnBot(this);
        public IEnemy OutsideView => new Enemy(this);
        private IOutput Output { get; }
        private IBotAI BotAI { get; }
        private Battlefield Battlefield { get; }
        private GameConfiguration Config { get; }

        public void ExecuteTurnAction(IReadOnlyCollection<Bot> enemies)
        {
            Thread.Sleep(Config.TurnActionDelay);
            if (HP <= 0)
            {
                return;
            }
            var turnAction = BotAI.GetTurnAction(InsideView, enemies.Select(e => e.OutsideView).ToList(), Battlefield);
            switch (turnAction)
            {
                case Move move:
                    Execute(move, Battlefield);
                    break;
                case Attack attack:
                    Execute(attack, enemies);
                    break;
                case Idle _:
                    Output.TurnAction(this, $"{Name} is idle.");
                    break;
                case RechargeShield rechargeShield:
                    Execute(rechargeShield);
                    break;
                case RechargeBattery rechargeBattery:
                    Execute(rechargeBattery);
                    break;
            }
        }

        private void Execute(Move move, Battlefield battlefield)
        {
            if (move.Direction == Direction.None)
            {
                Output.TurnAction(this, $"{Name} doesn't move.");
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

            if (EP < move.EnergyCost)
            {
                Output.TurnAction(this, $"{Name} doesn't have enough energy to move.");
                return;
            }
            if (battlefield.Move(this, newX, newY))
            {
                EP -= move.EnergyCost;
                Output.TurnAction(this, $"{Name} moved {move.Direction}.");
            }
            else
            {
                Output.TurnAction(this, $"{Name} cannot move {move.Direction}.");
            }
        }

        private void Execute(Attack attack, IReadOnlyCollection<Bot> enemies)
        {
            var target = enemies.FirstOrDefault(e => e.Name == attack.Target.Name);
            if (target == null)
            {
                Output.TurnAction(this, $"{Name} cannot attack {attack.Target.Name}.");
                return;
            }

            var distance = Position.DistanceTo(target.Position);
            const int maxRange = 10;
            if (distance > 10)
            {
                Output.TurnAction(this, $"{Name} cannot attack {target.Name}. Target is out of range.");
                return;
            }

            if (EP < attack.EnergyCost)
            {
                Output.TurnAction(this, $"{Name} doesn't have enough energy to attack.");
                return;
            }

            double chance = (maxRange - distance) / maxRange;
            const int maxDamage = 100;
            int damage = (int) (maxDamage * chance);

            EP -= attack.EnergyCost;

            if (damage <= 0)
            {
                Output.TurnAction(this, $"{Name} attacks {target.Name} with no damage.");
            }
            else
            {
                target.TakeDamage(damage);
                Output.TurnAction(this, $"{Name} attacks {target.Name} with {damage} damage.");
                if (target.HP <= 0)
                {
                    Output.TurnAction(target, $"{target.Name} explodes.");
                }
            }
        }

        private void Execute(RechargeShield rechargeShield)
        {
            if (EP < rechargeShield.EnergyCost)
            {
                Output.TurnAction(this, $"{Name} doesn't have enough energy to recharge shield.");
                return;
            }

            EP -= rechargeShield.EnergyCost;

            if (SP + rechargeShield.RechargeAmount < MaxSP)
            {
                SP += rechargeShield.RechargeAmount;
            }
            else
            {
                SP = MaxSP;
            }

            Output.TurnAction(this, $"{Name} recharges shield.");
        }

        private void Execute(RechargeBattery rechargeBattery)
        {
            if (EP < rechargeBattery.EnergyCost)
            {
                Output.TurnAction(this, $"{Name} doesn't have enough energy to recharge battery.");
                return;
            }

            EP -= rechargeBattery.EnergyCost;

            if (EP + rechargeBattery.RechargeAmount < MaxEP)
            {
                EP += rechargeBattery.RechargeAmount;
            }
            else
            {
                EP = MaxEP;
            }

            Output.TurnAction(this, $"{Name} recharges battery.");
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