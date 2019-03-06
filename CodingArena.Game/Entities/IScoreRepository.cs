using System.Collections.Generic;

namespace CodingArena.Game.Entities
{
    public interface IScoreRepository
    {
        List<Score> Load();
        void Save(List<Score> scores);
    }
}