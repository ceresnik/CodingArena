using System.Linq;
using CodingArena.Player.Implement;
using CodingArena.Player.TurnActions;

namespace CodingArena.Player.Example
{
    public class SeekAndDestroyBot : IBot
    {
        public SeekAndDestroyBot()
        {
            Name = "Seek and Destroy Bot";
            AI = new SeekAndDestroyAI();
        }

        public string Name { get; }
        public IBotAI AI { get; }
    }

    public class SeekAndDestroyAI : IBotAI
    {
        public ITurnAction CreateTurnAction(ITurn turn)
        {
            if (turn.Enemies.Any())
            {
                var robot = turn.MyRobot;
                var battlefield = turn.Battlefield;

                if (robot.EnergyPercentage < 50)
                {
                    return TurnAction.Recharge.Battery();
                }
                if (robot.ShieldPercentage < 50)
                {
                    return TurnAction.Recharge.Shield();
                }
                var closestEnemy = FindClosestEnemy(turn);
                if (battlefield[robot].DistanceTo(battlefield[closestEnemy]) < 50)
                {
                    return TurnAction.Attack.Target(closestEnemy);
                }

                return TurnAction.Move.Towards(battlefield[robot], battlefield[closestEnemy]);
            }

            return TurnAction.Idle();
        }

        private IEnemy FindClosestEnemy(ITurn turn) => 
            turn.Enemies
                .OrderBy(e => turn.Battlefield[e].DistanceTo(turn.Battlefield[turn.MyRobot]))
                .First();
    }
}