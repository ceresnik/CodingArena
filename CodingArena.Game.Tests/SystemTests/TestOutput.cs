using System;
using System.Collections.Generic;

namespace CodingArena.Game.Tests.SystemTests
{
    internal class TestOutput : IOutput
    {
        public void StartRound()
        {
        }

        public void NextRoundIn(TimeSpan delayForNextRound)
        {
        }

        public void Battlefield(Battlefield battlefield)
        {
        }

        public void NoBotsQualified()
        {
        }

        public void Qualified(Bot bot)
        {
        }

        public void Qualified(IList<Bot> bots)
        {
        }

        public void TurnAction(Bot bot, string message)
        {
        }

        public void RoundResult(RoundResult roundResult)
        {
        }
    }
}