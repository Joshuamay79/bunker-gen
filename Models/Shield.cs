namespace BunkerGen.Models
{
    public class Shield:IGuild
    {
        public int GuildId { get; set; }
        public string GuildName { get; set; }
        public List<int> LevelRange { get; set; }
        public int Capacity { get; set; }
        public int Recharge { get; set; }
        public string Effects { get; set; }
    }
}