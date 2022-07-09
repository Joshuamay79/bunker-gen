using BunkerGen.Models;

namespace BunkerGen.Services
{
    public class PotionService
    {
        private List<Potion> Potions;
        private List<TinaPotion> TinaPotions;
        private readonly DiceService DiceService;

        public static async Task<PotionService> BuildPotionService(DiceService diceService)
        {
            var p = await JsonLoaderService.Load<List<Potion>>(".\\resources\\loot\\potion.json");
            var tp = await JsonLoaderService.Load<List<TinaPotion>>(".\\resources\\loot\\tina-potion.json");
            return new PotionService(diceService, p, tp);
        }

        private PotionService(DiceService diceService, List<Potion> potions, List<TinaPotion> tinaPotions)
        {
            Potions = potions;
            TinaPotions = tinaPotions;
            DiceService = diceService;
        }
    }
}