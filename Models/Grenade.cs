namespace BunkerGen.Models
{
    public class Grenade
    {
        public int GuildId { get; set; }
        public string GuildName { get; set; }
        public List<int> LevelRange { get; set; }
        public string GrenadeType { get; set; }
        public string Damage { get; set; }
        public string Effects { get; set; }
    }
}