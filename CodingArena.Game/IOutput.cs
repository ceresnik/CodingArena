using System;
using System.Collections.Generic;
using CodingArena.Player.Battlefield;

namespace CodingArena.Game
{
    public interface IOutput
    {
        void StartRound();
        void NextRoundIn(TimeSpan delayForNextRound);
        void SetBattlefield(IBattlefield battlefield);
        void NoBotsQualified();
        void Qualified(Bot bot);
        void Qualified(IList<Bot> bots);
        void TurnAction(Bot bot, string message);
        void RoundResult(RoundResult roundResult);
        void MatchResult(Dictionary<string, int> winners);
        void Error(string message);
    }
}