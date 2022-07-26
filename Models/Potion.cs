namespace BunkerGen.Models
{
    public class Potion : IDieRange
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public int Cost { get; set; }
        public bool TinaPotion { get; set; }
        public int TinaModifier { get; set; }
        public List<int> DieRange { get; set; }
    }

    public class TinaPotion : IDie
    {
        public string Name { get; set; }
        public string Effect { get; set; }
        public int DieNumber { get; set; }
    }

}