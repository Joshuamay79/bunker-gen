using BunkerGen.Models;

namespace BunkerGen.Services
{
    public class RelicLoaderService
    {
        private readonly List<Relic> Relics;
        private readonly List<RelicClass> RelicClasses;
        private readonly DiceService DiceService;

        public static async Task<RelicLoaderService> BuildRelicLoaderService()
        {
            var relics = await JsonLoaderService.Load<List<Relic>>(".\\resources\\relics\\relic.json");

            var relicClasses = await JsonLoaderService.Load<List<RelicClass>>(".\\resources\\relics\\relic_class.json");

            return new RelicLoaderService(relics, relicClasses);
        }

        private RelicLoaderService(List<Relic> relics, List<RelicClass> relicClasses)
        {
            Relics = relics;
            RelicClasses = relicClasses;
            DiceService = new DiceService();
        }

        public Relic Execute()
        {
            var rcRoll = DiceService.Roll(DiceType.D10);
            var rc = RelicClasses.First(rcs => rcs.DieNumber == rcRoll);

            var rRoll = DiceService.Roll(DiceType.D100);
            var r = Relics.First(rs => rs.DieRange.Contains(rRoll));

            r.VhClass = rc.VhClass;

            return r;
        }
    }
}