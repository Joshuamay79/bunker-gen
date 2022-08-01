using System.Text.Json.Serialization;

namespace BunkerGen.Models
{

    public class GunTable: IDie
    {
        public int DieNumber { get; set; }
        public string GunType { get; set; }
        public string Bonus { get; set; }
        public List<GuildDie> Guilds { get; set; }
        public List<GunTableStat> Stats { get; set; }

        public class GunTableStat
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

    public class RarityTable : IDie
    {
        public int DieNumber { get; set; }
        public List<GunRarity> DiceRole { get; set; }

        public class GunRarity : IDie
        {
            public int DieNumber { get; set; }
            public string RarityInfo { get; set; }
            public bool Elemental { get; set; }
        }
    }

    public class ElementTable : IDieRange
    {
        public List<int> DieRange { get; set; }
        public List<ElementTableRarity> Rarities { get; set; }
    }

    public class ElementTableRarity : IDie
    {
        public int DieNumber { get; set; }
        public string Rarity { get; set; }
        public string Effect { get; set; }
    }

    public class GunGuild
    {
        public int GuildId { get; set; }
        public string GuildName { get; set; }
        public bool HasElement { get; set; }
        public string GunInfo { get; set; }
        public List<GunGuildRarity> Rarities { get; set; }
    }

    public class GunGuildRarity
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string Bonus { get; set; }
    }

    // public class Guildz
    // {
    //     public int DieNumber { get; set; }
    //     public int GuildId { get; set; }
    //     public string GuildName { get; set; }
    // }


}