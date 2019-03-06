using CodingArena.Game.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;

namespace CodingArena.Game.Internal
{
    [Export(typeof(IScoreRepository))]
    internal sealed class ScoreRepository : IScoreRepository
    {
        private const string ScoresFileName = "scores.json";

        public List<Score> Load()
        {
            var result = new List<Score>();
            if (!File.Exists(ScoresFileName)) return result;
            using (var reader = new StreamReader(ScoresFileName))
            {
                string json = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<Score>>(json);
            }

            return result;
        }

        public void Save(List<Score> scores)
        {
            using (var writer = File.CreateText(ScoresFileName))
            {
                var serializer = new JsonSerializer { Formatting = Formatting.Indented };
                serializer.Serialize(writer, scores);
            }
        }
    }
}