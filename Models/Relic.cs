namespace BunkerGen.Models
{
    public class Relic : IDieRange
    {
        public List<int> DieRange { get; set; }
        public string relicType { get; set; }
        public string effect { get; set; }
        public string classEffect { get; set; }
        public string rarity { get; set; }

        public string VhClass { get; set; }
    }

    public class RelicClass : IDie
    {
        public int DieNumber { get; set; }
        public string VhClass { get; set; }
    }
}