using BunkerGen.Models;

namespace BunkerGen.Services
{
    public class GunService
    {
        private readonly DiceService DiceService;
        private List<GunTable> gunType;
        private List<RarityTable> rarity;
        private List<ElementTable> elemental;
        private List<GunGuild> gunGuild;
        private List<Prefix> prefix;
        private List<RedText> redText;

        public static async Task<GunService> BuildGunService(DiceService diceService)
        {
            var gunType = await JsonLoaderService.Load<List<GunTable>>(".\\resources\\guns\\gun_table.json");
            var rarity = await JsonLoaderService.Load<List<RarityTable>>(".\\resources\\guns\\rarity_table.json");
            var elemental = await JsonLoaderService.Load<List<ElementTable>>(".\\resources\\guns\\elemental_table.json");
            var gunGuild = await JsonLoaderService.Load<List<GunGuild>>(".\\resources\\guns\\gun_guild.json");
            var prefix = await JsonLoaderService.Load<List<Prefix>>(".\\resources\\guns\\prefix.json");
            var redText = await JsonLoaderService.Load<List<RedText>>(".\\resources\\guns\\red_text.json");

            return new GunService(diceService, gunType, rarity, elemental, gunGuild, prefix, redText);
        }

        public GunService(DiceService diceService, List<GunTable> gunType, List<RarityTable> rarity, List<ElementTable> elemental, List<GunGuild> gunGuild, List<Prefix> prefix, List<RedText> redText)
        {
            DiceService = diceService;
            this.gunType = gunType;
            this.rarity = rarity;
            this.elemental = elemental;
            this.gunGuild = gunGuild;
            this.prefix = prefix;
            this.redText = redText;
        }

        public void Execute(int Level)
        {
            var d8_1 = DiceService.Roll(DiceType.D8);
            var d8_2 = DiceService.Roll(DiceType.D8);
            var d4 = DiceService.Roll(DiceType.D4);
            var d6 = DiceService.Roll(DiceType.D6);
            var d100_elemental = DiceService.Roll(DiceType.D100);
            var d100_prefix = DiceService.Roll(DiceType.D100);
            var d100_redText = DiceService.Roll(DiceType.D100);

            var gunTable = gunType.First(gt => gt.DieNumber == d8_1);
            var gunTableGuild = gunTable.Guilds.First(gt => gt.DieNumber == d8_2);
            var rarityTable = rarity.First(r => r.DieNumber == d4);
            var rarityTableRarity = rarityTable.GunRarities.First(r => r.DieNumber == d6);
            var gunGuildTable = gunGuild.First(gg => gg.GuildId == gunTableGuild.GuildId);

            if (rarityTableRarity.HasElement || gunGuildTable.HasElement)
            {
                var element = elemental.First(e => e.DieRange.Contains(d100_elemental));
            }

            if (rarityTableRarity.RarityId == 4 || rarityTableRarity.RarityId == 5)
            {
                var redTdext = redText.First(rt => rt.DieRange.Contains(d100_redText));
            }

            var usePrefix = true;

            if (usePrefix)
            {
                var pref = prefix.First(p => p.DieNumber == d100_prefix);
            }
        }
    }
}