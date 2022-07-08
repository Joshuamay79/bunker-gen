using BunkerGen.Models;

namespace BunkerGen.Services
{
    public interface ILootProcessorService
    {
        List<Loot> Execute(int numberOfPiles);
    }

    public class LootProcessorService : ILootProcessorService
    {
        private readonly List<LootPile> LootPiles;
        private readonly DiceService DiceService;


        public static async Task<LootProcessorService> BuildLootProcessorService()
        {
            var lootPiles = await JsonLoaderService.Load<List<LootPile>>(".\\resources\\loot-drop.json");
            return new LootProcessorService(lootPiles);
        }
        private LootProcessorService(List<LootPile> lootDrops)
        {
            LootPiles = lootDrops;
            DiceService = new DiceService();
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