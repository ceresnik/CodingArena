using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingArena.Game.Entities;

namespace CodingArena.Game.Internal
{
    internal sealed class BattleBot : IBattleBot
    {
        private IBotAI BotAI { get; }
        private IBattlefield Battlefield { get; set; }
        private ISettings Settings { get; }

        public BattleBot(IBotAI botAI, ISettings settings)
        {
            BotAI = botAI;
            Settings = settings;
            MaxHP = Settings.MaxHP;
            HP = MaxHP;
            MaxSP = Settings.MaxSP;
            SP = MaxSP;
            MaxEP = Settings.MaxEP;
            EP = MaxEP;
            InsideView = new InsideView(this);
            OutsideView = new OutsideView(this);
        }

        public string Name => BotAI.BotName;

        public int MaxHP { get; }

        public int HP { get; private set; }

        public int MaxEP { get; }

        public int EP { get; private set; }

        public int MaxSP { get; }

        public int SP { get; private set; }

        public IBattlefieldPlace Position => Battlefield?[this];

        public IOwnBot InsideView { get; }
        public IEnemy OutsideView { get; }
        public string DestroyedBy { get; set; }

        public void PositionTo(IBattlefield battlefield, int newX, int newY)
        {
            Battlefield = battlefield;
            Battlefield.Set(this, newX, newY);
        }

        public string ExecuteTurnAction(IEnumerable<IBattleBot> enemies)
        {
            if (HP <= 0) return $"{Name} is destroyed by {DestroyedBy}.";
            ITurnAction turnAction;
            try
            {
                turnAction = GetTurnAction(enemies);
            }
            catch (Exception)
            {
                Destroy("system malfunction");
                return $"{Name} is destroyed by {DestroyedBy}.";
            }
            if (turnAction == null)
            {
                Destroy("system malfunction");
                return $"{Name} is destroyed by {DestroyedBy}.";
            }
            switch (turnAction)
            {
                case Move move:
                    return ExecuteTurnAction(move);
                case RechargeBattery rechargeBattery:
                    return ExecuteTurnAction(rechargeBattery);
                case RechargeShield rechargeShield:
                    return ExecuteTurnAction(rechargeShield);
                case Attack attack:
                    return ExecuteTurnAction(attack, enemies);
                case Idle idle:
                    return $"{Name} is idle.";
            }

            Destroy("system malfunction");
            return $"{Name} is destroyed by {DestroyedBy}.";
        }

        private ITurnAction GetTurnAction(IEnumerable<IBattleBot> enemies)
        {
            ITurnAction result = null;
            var task = Task.Run(() =>
                result = BotAI.GetTurnAction(
                    InsideView, enemies.Select(e => e.OutsideView).ToList(), Battlefield));
            var timeout = TimeSpan.FromSeconds(1);
            var success = task.Wait(timeout);
            if (!success)
                throw new TimeoutException($"GetTurnAction is not complete after timeout {timeout}.");

            return result;
        }

        private string ExecuteTurnAction(Attack attack, IEnumerable<IBattleBot> enemies)
        {
            if (attack.EnergyCost > EP)
                return $"{Name} does not have enough energy to attack.";

            var ownPlace = Battlefield[this];
            var targetPlace = Battlefield[attack.Target];
            var distance = ownPlace.DistanceTo(targetPlace);
            DrainEnergy(attack.EnergyCost);
            var damage = CalculateDamage(distance);
            var enemy = enemies.FirstOrDefault(e => e.OutsideView == attack.Target);

            if (enemy == null)
                return $"{Name} wants to attack, but enemy is not found on battlefield.";

            if (enemy.HP <= 0)
                return $"{Name} attempts to attack {enemy.Name} but failed, target is already destroyed.";

            if (distance > Attack.MaxRange)
                return $"{Name} attempts to attack {enemy.Name} but failed, target is out of range.";

            if (damage <= 0)
                return $"{Name} attacks {enemy.Name} with no damage.";

            enemy.TakeDamage(damage, this);

            return enemy.HP <= 0 
                ? $"{Name} destroys {enemy.Name}." 
                : $"{Name} attacks {enemy.Name} with {damage} damage.";
        }

        private int CalculateDamage(double distance)
        {
            if (distance > Attack.MaxRange) return 0;
            var chance = (Attack.MaxRange - distance + 1) / Attack.MaxRange;
            return (int)(Attack.MaxDamage * chance);
        }

        private string ExecuteTurnAction(Move move)
        {
            if (move.EnergyCost > EP)
                return $"{Name} does not have enough energy to move.";

            int newX = Position.X;
            int newY = Position.Y;

            switch (move.Direction)
            {
                case Direction.East:
                    newX = Position.X + 1;
                    break;
                case Direction.West:
                    newX = Position.X - 1;
                    break;
                case Direction.South:
                    newY = Position.Y - 1;
                    break;
                case Direction.North:
                    newY = Position.Y + 1;
                    break;
            }

            if (Battlefield.IsOutOfRange(newX, newY))
            {
                Destroy("battlefield force field");
                return $"{Name} moved into battlefield force field and exploded.";
            }

            DrainEnergy(move.EnergyCost);
            PositionTo(newX, newY);
            return $"{Name} moved {move.Direction}.";
        }

        private void PositionTo(int newX, int newY) => PositionTo(Battlefield, newX, newY);

        private string ExecuteTurnAction(RechargeBattery rechargeBattery)
        {
            if (rechargeBattery.EnergyCost > EP)
                return $"{Name} does not have enough energy to recharge battery.";
            DrainEnergy(rechargeBattery.EnergyCost);
            EP += rechargeBattery.RechargeAmount;
            if (EP > MaxEP) EP = MaxEP;
            return $"{Name} recharges battery.";
        }

        private string ExecuteTurnAction(RechargeShield rechargeShield)
        {
            int amount;
            if (EP == 0)
            {
                return $"{Name} does not have enough energy to recharge shield.";
            }
            if (rechargeShield.EnergyCost > EP)
            {
                amount = EP;
                DrainEnergy(EP);
                if (SP + amount > MaxSP)
                {
                    amount = MaxSP - SP;
                }
                if (SP == MaxSP) return $"{Name} wants to recharge shield, but it's already full.";
                SP += amount;
                return $"{Name} recharges shield by {amount} SP.";
            }
            if (SP == MaxSP) return $"{Name} wants to recharge shield, but it's already full.";
            DrainEnergy(rechargeShield.EnergyCost);
            amount = rechargeShield.RechargeAmount;
            if (SP + amount > MaxSP)
            {
                amount = MaxSP - SP;
            }
            SP += amount;
            return $"{Name} recharges shield by {amount} SP.";
        }

        public void DrainEnergy(int energyPoints)
        {
            EP -= energyPoints;
            if (EP < 0) EP = 0;
        }

        public void TakeDamage(int damage) => TakeDamage(damage, null);

        public void TakeDamage(int damage, IBattleBot attacker)
        {
            SP -= damage;
            if (SP < 0)
            {
                HP += SP;
                SP = 0;
                if (HP <= 0)
                {
                    if (attacker != null)
                    {
                        Destroy(attacker);
                    }
                    else
                    {
                        Destroy("unknown force");
                    }
                }
            }
        }

        private void Destroy(IBattleBot attacker)
        {
            attacker.Kills++;
            Destroy(attacker.Name);
        }

        private void Destroy(string cause)
        {
            HP = 0;
            Deaths++;
            DestroyedBy = cause;
            OnExploded();
        }

        public event EventHandler Exploded;
        private void OnExploded() => Exploded?.Invoke(this, EventArgs.Empty);

        public int Kills { get; set; }

        public int Deaths { get; set; }

        public double DistanceTo(IOwnBot insideView) => Position.DistanceTo(Battlefield[insideView]);

        public double DistanceTo(IEnemy outsideView) => Position.DistanceTo(Battlefield[outsideView]);

        public override string ToString() => Name;
    }
}