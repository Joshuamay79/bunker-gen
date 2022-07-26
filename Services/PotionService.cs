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

        public Potion Execute()
        {
            var p = DiceService.Roll(DiceType.D20);
            var potion = Potions.First(t => t.DieRange.Contains(p));
            if (potion.TinaPotion)
            {
                var tp = DiceService.Roll(DiceType.D20) + potion.TinaModifier;
                var tPotion = TinaPotions.First(t => t.DieNumber == tp);
                potion.Name = tPotion.Name;
                potion.Effect = tPotion.Effect;
            }
            return potion;
        }
    }
}