using System.Text.Json.Serialization;

namespace BunkerGen.Models
{

public class Gun
{
    public string GunType { get; set; }
    public string Range { get; set; }
    public string Shots=>"Convert 2-x acc roll class details";
     
}

    public class GunTable: IDie
    {
        public int DieNumber { get; set; }
        public string GunType { get; set; }
        public string Bonus { get; set; }
        public List<GuildDie> Guilds { get; set; }
        public List<GunTableStat> Stats { get; set; }

        public class GunTableStat
        {
            public List<int> LevelRange { get; set; }

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
        public List<GunRarity> GunRarities { get; set; }

        public class GunRarity : RarityDie
        {
            public bool HasElement { get; set; }
        }
    }

    public class ElementTable : IDieRange
    {
        public List<int> DieRange { get; set; }
        public List<ElementTableRarity> Rarities { get; set; }
        public class ElementTableRarity:Rarity{
public string Effect { get; set; }
        }
    }

    public class GunGuild:Guild
    {
        public bool HasElement { get; set; }
        public string GunInfo { get; set; }
        public List<GunGuildRarity> Rarities { get; set; }
        
    public class GunGuildRarity:Rarity
    {
        public string Bonus { get; set; }
        public int? ElementalRoll { get; set; }
    }
    }
}