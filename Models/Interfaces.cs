namespace BunkerGen.Models
{
    public interface IDie
    {
        int DieNumber { get; set; }
    }

    public interface IDieRange
    {
        List<int> DieRange { get; set; }
    }

    public interface IGuild
    {
        int GuildId { get; set; }
        string GuildName { get; set; }
    }

    public interface IGuildDie : IDie, IGuild { }

    public interface IRarity
    {
        int RarityId { get; set; }
        string RarityName { get; set; }
    }

    public interface IRarityDie : IRarity, IDie { }
}