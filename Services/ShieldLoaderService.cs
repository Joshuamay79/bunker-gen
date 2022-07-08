using BunkerGen.Models;

namespace BunkerGen.Services
{
    public class ShieldLoaderService
    {
        private List<GuildDie> GuildDice;
        private List<Shield> Shields;
        private List<Guild> Guilds;
        private readonly DiceService DiceService;

        public static async Task<ShieldLoaderService> BuildShieldLoaderService()
        {
            var gd = await JsonLoaderService.Load<List<GuildDie>>(".\\resources\\shields\\shield_guild.json");
            var s = await JsonLoaderService.Load<List<Shield>>(".\\resources\\shields\\shield.json");
            var g = await JsonLoaderService.Load<List<Guild>>(".\\resources\\guilds\\guilds.json");
            return new ShieldLoaderService(gd, s, g);
        }

        private ShieldLoaderService(List<GuildDie> guildDice, List<Shield> shields, List<Guild> guilds)
        {
            GuildDice = guildDice;
            Shields = shields;
            Guilds = guilds;
            DiceService = new DiceService();
        }

        public Shield Execute(int level)
        {
            var gRoll = DiceService.Roll(DiceType.D8);
            var g = GuildDice.First(gu => gu.DieNumber == gRoll);

            var s = Shields.First(sh => sh.GuildId == g.GuildId && sh.LevelRange.Contains(level));
            return s;
        }
    }
}