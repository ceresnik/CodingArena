using System;
using System.Collections.Generic;

namespace CodingArena.Game
{
    public interface IOutput
    {
        void StartRound();
        void NextRoundIn(TimeSpan delayForNextRound);
        void Battlefield(Battlefield battlefield);
        void NoBotsQualified();
        void Qualified(Bot bot);
        void Qualified(IList<Bot> bots);
        void TurnAction(Bot bot, string message);
        void RoundResult(RoundResult roundResult);
        void MatchResult(Dictionary<string, int> winners);
    }
}