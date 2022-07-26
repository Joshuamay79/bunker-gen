namespace BunkerGen.Models
{
    public class LootPile
    {
        public int PileNumber { get; set; }
        public List<Loot> Loot { get; set; }
    }

    public class Loot:IDie
    {
        public int DieNumber { get; set; }
        public string Description { get; set; }
        public bool GeneratesItem { get; set; }

        // JSON needs values set
        public ResourceType ResourceType { get; set; }
        public ResourceRarity ResourceRarity { get; set; }
    }

    public enum ResourceType
    {
        Gold,Potion,GrenadeQuantity,
        Gun, GrenadeMod, ShieldMod, Relic
    }

    public enum ResourceRarity
    {
        Common, Uncommon, Rare, Epic, Legendary
    }
}