using System.Text.Json.Serialization;

namespace BunkerGen.Models
{
    public class Rarity : IRarity
    {
        public int RarityId { get ; set ; }
        [JsonPropertyName("rarity")]
        public string RarityName { get ; set ; }
    }

    public class RarityDie : IRarityDie
    {
        public int RarityId { get ; set ; }
        [JsonPropertyName("rarity")]
        public string RarityName { get ; set ; }
        public int DieNumber { get ; set ; }
    }
}