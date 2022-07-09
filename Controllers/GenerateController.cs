using BunkerGen.Models;
using BunkerGen.Services;
using Microsoft.AspNetCore.Mvc;

namespace BunkerGen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateController : ControllerBase
    {
        private readonly ILogger<GenerateController> _logger;
        private readonly DiceService DiceService = new DiceService();

        public GenerateController(ILogger<GenerateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public List<string> Index()
        {
            return new List<string>
            {
"https://localhost:7185/generate/piles?piles=1",
"https://localhost:7185/generate/relic",
"https://localhost:7185/generate/shield?level=1",
"https://localhost:7185/generate/grenade?level=1",
"https://localhost:7185/generate/gun?level=1",
"https://localhost:7185/generate/potion",
"https://localhost:7185/generate/cache-roll?cacheSize=1",
"https://localhost:7185/generate/unassuming-chest",
"https://localhost:7185/generate/dice-chest",
"https://localhost:7185/generate/trauma"
            };
        }

        [HttpGet]
        [Route("piles")]
        public async Task<List<Loot>> GetLootDrops(int piles)
        {
            var g = await LootService.BuildLootProcessorService(DiceService);
            var m = g.Execute(piles);

            return m;
        }

        [HttpGet]
        [Route("relic")]
        public async Task<Relic> GetRelic()
        {
            var s = await RelicService.BuildRelicLoaderService(DiceService);
            var r = s.Execute();

            return r;
        }

        [HttpGet]
        [Route("shield")]
        public async Task<Shield> GetShield(int level)
        {
            var r = await ShieldService.BuildShieldLoaderService(DiceService);
            var s = r.Execute(level);

            return s;
        }

        [HttpGet]
        [Route("grenade")]
        public async Task<Grenade> GetGrenade(int level)
        {
            var r = await GrenadeService.BuildGrenadeLoaderService(DiceService);
            var s = r.Execute(level);

            return s;
        }

        [HttpGet]
        [Route("gun")]
        public async Task<Grenade> GetGun(int level)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("potion")]
        public async Task<Grenade> GetPotion()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("cache-roll")]
        public async Task<Grenade> GetCacheRoll(int cacheSize)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("unassuming-chest")]
        public async Task<Grenade> GetUnassumingChest()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("dice-chest")]
        public async Task<Grenade> GetDiceChest()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("trauma")]
        public async Task<Trauma> GetTrauma()
        {
            var service = await TraumaService.BuildTraumaService(DiceService);
            var trauma = service.Execute();

            return trauma;
        }
    }
}