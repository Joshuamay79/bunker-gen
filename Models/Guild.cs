namespace BunkerGen.Models
{
    public class Guild : GuildDie
    {
        public string GuildName { get; set; }
    }


    public class GuildDie : IGuildDie
    {
        public int DieNumber { get; set; }
        public int GuildId { get; set; }
    }
}