using CodingArena.Player;
using CodingArena.Player.Battlefield;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodingArena.Game.Internal
{
    internal sealed class BattleBot : IBattleBot
    {
        private IBotAI BotAI { get; }
        private IBattlefield Battlefield { get; }
        private ISettings Settings { get; }

        public BattleBot(IBotAI botAI, IBattlefield battlefield, ISettings settings)
        {
            BotAI = botAI;
            Battlefield = battlefield;
            Settings = settings;
            MaxHP = Settings.MaxHP;
            HP = MaxHP;
            MaxSP = Settings.MaxSP;
            SP = MaxSP;
            MaxEP = Settings.MaxEP;
            EP = MaxEP;
        }

        public string Name => BotAI.BotName;

        public int MaxHP { get; }

        public int HP { get; private set; }

        public int MaxEP { get; }

        public int EP { get; private set; }

        public int MaxSP { get; }

        public int SP { get; private set; }

        public IBattlefieldPlace Position => Battlefield[this];
        public IEnemy OutsideView => new OutsideView(this);


        public void PositionTo(int newX, int newY)
        {
            Battlefield.Set(this, newX, newY);
        }

        public void ExecuteTurnAction(IEnumerable<IBattleBot> enemies)
        {
            var turnAction = BotAI.GetTurnAction(null, null, null);
            switch (turnAction)
            {
                case Move move:
                    ExecuteTurnAction(move);
                    break;
                case RechargeBattery rechargeBattery:
                    ExecuteTurnAction(rechargeBattery);
                    break;
                case RechargeShield rechargeShield:
                    ExecuteTurnAction(rechargeShield);
                    break;
                case Attack attack:
                    ExecuteTurnAction(attack, enemies);
                    break;
            }
        }

        private void ExecuteTurnAction(Attack attack, IEnumerable<IBattleBot> enemies)
        {
            if (attack.EnergyCost > EP) return;

            var distance = Battlefield[this].DistanceTo(Battlefield[attack.Target]);
            DrainEnergy(attack.EnergyCost);
            var damage = CalculateDamage(distance);
            if (damage > 0)
            {
                var enemy = enemies.FirstOrDefault(e => e.OutsideView == attack.Target);
                enemy?.TakeDamage(damage);
            }
        }

        private int CalculateDamage(double distance)
        {
            if (distance >= Attack.MaxRange) return 0;
            var chance = (Attack.MaxRange - distance) / Attack.MaxRange;
            return (int)(Attack.MaxDamage * chance);
        }

        private void ExecuteTurnAction(Move move)
        {
            if (move.EnergyCost > EP) return;

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
                Explode();
            }
            else
            {
                DrainEnergy(move.EnergyCost);
                PositionTo(newX, newY);
            }
        }

        private void ExecuteTurnAction(RechargeBattery rechargeBattery)
        {
            if (rechargeBattery.EnergyCost > EP) return;
            DrainEnergy(rechargeBattery.EnergyCost);
            EP += rechargeBattery.RechargeAmount;
            if (EP > MaxEP) EP = MaxEP;
        }

        private void ExecuteTurnAction(RechargeShield rechargeShield)
        {
            if (rechargeShield.EnergyCost > EP) return;
            if (SP == MaxSP) return;
            DrainEnergy(rechargeShield.EnergyCost);
            SP += rechargeShield.RechargeAmount;
            if (SP > MaxSP) SP = MaxSP;
        }

        public void DrainEnergy(int energyPoints)
        {
            EP -= energyPoints;
            if (EP < 0) EP = 0;
        }

        public void TakeDamage(int damage)
        {
            SP -= damage;
            if (SP < 0)
            {
                HP += SP;
                SP = 0;
                if (HP < 0) HP = 0;
            }
        }

        private void Explode()
        {
            HP = 0;
            OnExploded();
        }

        public event EventHandler Exploded;

        private void OnExploded() => Exploded?.Invoke(this, EventArgs.Empty);
    }
}