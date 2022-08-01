namespace BunkerGen.Models
{
    public class Grenade:IGuild
    {
        public int GuildId { get; set; }
        public string GuildName { get; set; }
        public List<int> LevelRange { get; set; }
        public string GrenadeType { get; set; }
        public string Damage { get; set; }
        public string Effects { get; set; }
    }
}