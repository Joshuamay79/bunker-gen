using BunkerGen.Models;

namespace BunkerGen.Services
{
    public class RelicService
    {
        private readonly List<Relic> Relics;
        private readonly List<RelicClass> RelicClasses;
        private readonly DiceService DiceService;

        public static async Task<RelicService> BuildRelicLoaderService(DiceService diceService)
        {
            var relics = await JsonLoaderService.Load<List<Relic>>(".\\resources\\relics\\relic.json");

            var relicClasses = await JsonLoaderService.Load<List<RelicClass>>(".\\resources\\relics\\relic_class.json");

            return new RelicService(diceService, relics, relicClasses);
        }

        private RelicService(DiceService diceService, List<Relic> relics, List<RelicClass> relicClasses)
        {
            Relics = relics;
            RelicClasses = relicClasses;
            DiceService = diceService;
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