using System.Text.Json.Serialization;

namespace BunkerGen.Models
{
    public class Gun
    {

    }

    public class GunGuild
    {
        public int GuildId { get; set; }
        public string GuildName { get; set; }
        public bool HasElement { get; set; }
        public string GunInfo { get; set; }
        public List<Rarity> Rarities { get; set; }
    }

    public class Rarity
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string Bonus { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Guildz
    {
        public int DieNumber { get; set; }
        public int GuildId { get; set; }
        public string GuildName { get; set; }
    }

    public class Root
    {
        public int DieNumber { get; set; }
        public string GunType { get; set; }
        public string bonus { get; set; }
        public List<Guild> Guilds { get; set; }
        public List<Stat> stats { get; set; }
    }

    public class Stat
    {
        public int gunId { get; set; }
        public string name { get; set; }
        public string level { get; set; }

        [JsonPropertyName("ac2-7_hit")]
        public int Ac27Hit { get; set; }

        [JsonPropertyName("ac2-7_crit")]
        public int Ac27Crit { get; set; }

        [JsonPropertyName("ac8-15_hit")]
        public int Ac815Hit { get; set; }

        [JsonPropertyName("ac8-15_crit")]
        public int Ac815Crit { get; set; }

        [JsonPropertyName("ac16+_hit")]
        public int Ac16Hit { get; set; }

        [JsonPropertyName("ac16+_crit")]
        public int Ac16Crit { get; set; }
        public string damage { get; set; }
        public int range { get; set; }
    }


}