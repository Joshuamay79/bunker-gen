namespace BunkerGen.Models
{
    public interface IDie
    {
        int DieNumber { get; set; }
    }

    public interface IGuildDie : IDie
    {
        int GuildId { get; set; }
    }

    public interface IDieRange
    {
        List<int> DieRange { get; set; }
    }
}