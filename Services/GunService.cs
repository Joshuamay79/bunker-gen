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
            var gun = new Gun();
            var d8_1 = DiceService.Roll(DiceType.D6); // only roll as d6 because favored weapon
            var d8_2 = DiceService.Roll(DiceType.D8);
            var d4 = DiceService.Roll(DiceType.D4);
            var d6 = DiceService.Roll(DiceType.D6);
            var d100_elemental = DiceService.Roll(DiceType.D100);
            var d100_prefix = DiceService.Roll(DiceType.D100);
            var d100_redText = DiceService.Roll(DiceType.D100);

            Console.WriteLine($"d8_1 - {d8_1}, d8_2 - {d8_2}, d4 - {d4}, d6 - {d6}, d100_el - {d100_elemental}, d100_pre - {d100_prefix}, d100_red - {d100_redText}");
// Error - d8_1 - 8, d8_2 - 3, d4 - 1, d6 - 4, d100_el - 27, d100_pre - 80, d100_red - 76

            var gunTable = gunType.First(gt => gt.DieNumber == d8_1);
            gun.GunType = gunTable.GunType;
            gun.GunTypeBonus = gunTable.Bonus;
            var gunStats = gunTable.Stats.First(g => g.LevelRange.Contains(Level));
            gun.Range = gunStats.range;
            gun.Ac27Hit = gunStats.Ac27Hit;
            gun.Ac27Crit = gunStats.Ac27Crit;
            gun.Ac815Hit = gunStats.Ac815Hit;
            gun.Ac815Crit = gunStats.Ac815Crit;
            gun.Ac16Hit = gunStats.Ac16Hit;
            gun.Ac16Crit = gunStats.Ac16Crit;
            gun.Damage = gunStats.damage;

            var gunTableGuild = gunTable.Guilds.First(gt => gt.DieNumber == d8_2);
            var rarityTable = rarity.First(r => r.DieNumber == d4);
            var rarityTableRarity = rarityTable.GunRarities.First(r => r.DieNumber == d6);
            gun.Rarity = rarityTableRarity.RarityName;

            var gunGuildTable = gunGuild.First(gg => gg.GuildId == gunTableGuild.GuildId);

            gun.Guild = gunGuildTable.GuildName;
            gun.GuildEffect = gunGuildTable.GunInfo;

            if (rarityTableRarity.HasElement || gunGuildTable.HasElement)
            {
                var elementTable = elemental.First(e => e.DieRange.Contains(d100_elemental));
                var elementValue = elementTable.Rarities.First(e => e.RarityId == rarityTableRarity.RarityId);
                var effect = elementValue.Effect;
                gun.Elemental = effect;
            }

            // 4 = epic
            // 5 = legendary
            if (rarityTableRarity.RarityId == 4 || rarityTableRarity.RarityId == 5)
            {
                var reddText = redText.First(rt => rt.DieRange.Contains(d100_redText));
                gun.RedText = reddText.Text;
                gun.RedTextEffect = reddText.Effect;
            }

            var usePrefix = true;

            if (usePrefix)
            {
                var pref = prefix.First(p => p.DieNumber == d100_prefix);
                gun.Prefix = pref.Text;
                gun.PrefixEffect = pref.Effect;
            }
        }
    }
}