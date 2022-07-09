using BunkerGen.Models;

namespace BunkerGen.Services
{
    public class LootService
    {
        private readonly List<LootPile> LootPiles;
        private readonly DiceService DiceService;


        public static async Task<LootService> BuildLootProcessorService(DiceService diceService)
        {
            var lootPiles = await JsonLoaderService.Load<List<LootPile>>(".\\resources\\loot\\loot-drop.json");
            return new LootService(diceService, lootPiles);
        }
        private LootService(DiceService diceService, List<LootPile> lootDrops)
        {
            LootPiles = lootDrops;
            DiceService = diceService;
        }

        public List<Loot> Execute(int numberOfPiles)
        {
            var l = LootPiles
            .Where(lp => lp.PileNumber <= numberOfPiles);

            return l.Select(lp =>
            {
                var r = DiceService.Roll(DiceType.D4);
                var p = lp.Loot.FirstOrDefault(lpl => lpl.DieNumber == r);
                return p;
            })
            .ToList();
        }
    }
}