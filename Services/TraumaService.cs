using BunkerGen.Models;

namespace BunkerGen.Services
{
    public class TraumaService
    {
        private List<Trauma> Traumas;
        private readonly DiceService DiceService;

        public static async Task<TraumaService> BuildTraumaService(DiceService diceService)
        {
            var t = await JsonLoaderService.Load<List<Trauma>>(".\\resources\\trauma.json");
            return new TraumaService(diceService, t);
        }

        private TraumaService(DiceService diceService, List<Trauma> traumas)
        {
            Traumas = traumas;
            DiceService = diceService;
        }

        public Trauma Execute()
        {
            var tRoll = DiceService.Roll(DiceType.D20);

            if (tRoll == 1)
            {
                var permRoll = DiceService.Roll(DiceType.D20);
                var permTrauma = Traumas.First(t => t.IsPermanent && t.DieNumber == permRoll);
                return permTrauma;
            }
            else
            {
                var trauma = Traumas.First(t => !t.IsPermanent && t.DieNumber == tRoll);
                return trauma;
            }
        }
    }
}