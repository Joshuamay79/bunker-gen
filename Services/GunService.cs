namespace BunkerGen.Services
{
    public class GunService
    {


        private readonly DiceService DiceService;

        public static async Task<GunService> BuildGunService(DiceService diceService)
        {
            // var elemental = await JsonLoaderService.Load<List<LootPile>>(".\\resources\\guns\\elemental.json");
            // var gunGuild = await JsonLoaderService.Load<List<LootPile>>(".\\resources\\guns\\gun_guild.json");
            // var gunType = await JsonLoaderService.Load<List<LootPile>>(".\\resources\\guns\\gun_type.json");
            // var prefix = await JsonLoaderService.Load<List<LootPile>>(".\\resources\\guns\\prefix.json");
            // var rarity = await JsonLoaderService.Load<List<LootPile>>(".\\resources\\guns\\rarity.json");
            // var redText = await JsonLoaderService.Load<List<LootPile>>(".\\resources\\guns\\red_text.json");
            
            return new GunService(diceService);
        }

        private GunService(DiceService diceService)
        {

            DiceService = diceService;
        }
    }
}