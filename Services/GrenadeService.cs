using BunkerGen.Models;
using System.Text.Json;

namespace BunkerGen.Services
{
    public class GrenadeService
    {
        private readonly List<GuildDie> GuildDice;
        private readonly List<Grenade> Grenades;
        private readonly List<Guild> Guilds;
        private readonly List<Element> Element;
        private readonly DiceService DiceService;

        public static async Task<GrenadeService> BuildGrenadeLoaderService(DiceService diceService)
        {
            var gd = await JsonLoaderService.Load<List<GuildDie>>(".\\resources\\grenades\\grenade_guild.json");
            var s = await JsonLoaderService.Load<List<Grenade>>(".\\resources\\grenades\\grenade.json");
            var g = await JsonLoaderService.Load<List<Guild>>(".\\resources\\guilds\\guilds.json");
            var e = await JsonLoaderService.Load<List<Element>>(".\\resources\\elemental_type.json");
            return new GrenadeService(diceService, gd, s, g, e);
        }

        private GrenadeService(DiceService diceService, List<GuildDie> guildDice, List<Grenade> grenades, List<Guild> guilds, List<Element> e)
        {
            GuildDice = guildDice;
            Grenades = grenades;
            Guilds = guilds;
            Element = e;
            DiceService = diceService;
        }

        public Grenade Execute(int level)
        {
            var gRoll = DiceService.Roll(DiceType.D8);
            var elementalRoll = DiceService.Roll(DiceType.D6);
            var g = GuildDice.First(gu => gu.DieNumber == gRoll);

            var s = Grenades.First(sh => sh.GuildId == g.GuildId && sh.LevelRange.Contains(level));

            if (s.HasElemental)
            {
                var el = Element.First(e => e.DieNumber == elementalRoll);
                s.Effects = $"{s.Effects}: {el.Description}";
            }

            s.LevelRange = null;
            return s;
        }
    }
}