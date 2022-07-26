using BunkerGen.Models;
using System.Text.Json;

namespace BunkerGen.Services
{
    public class GrenadeService
    {
        private List<GuildDie> GuildDice;
        private List<Grenade> Grenades;
        private List<Guild> Guilds;
        private readonly DiceService DiceService;

        public static async Task<GrenadeService> BuildGrenadeLoaderService(DiceService diceService)
        {
            var gd = await JsonLoaderService.Load<List<GuildDie>>(".\\resources\\grenades\\grenade_guild.json");
            var s = await JsonLoaderService.Load<List<Grenade>>(".\\resources\\grenades\\grenade.json");
            var g = await JsonLoaderService.Load<List<Guild>>(".\\resources\\guilds\\guilds.json");

            return new GrenadeService(diceService, gd, s, g);
        }

        private GrenadeService(DiceService diceService, List<GuildDie> guildDice, List<Grenade> grenades, List<Guild> guilds)
        {
            GuildDice = guildDice;
            Grenades = grenades;
            Guilds = guilds;
            DiceService = diceService;
        }

        public Grenade Execute(int level)
        {
            var gRoll = DiceService.Roll(DiceType.D8);
            var g = GuildDice.First(gu => gu.DieNumber == gRoll);

            var s = Grenades.First(sh => sh.GuildId == g.GuildId && sh.LevelRange.Contains(level));
            SQLiteService.Add(1,JsonSerializer.Serialize(s));
            return s;
        }
    }
}