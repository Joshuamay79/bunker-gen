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

        public GenerateController(ILogger<GenerateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("piles")]
        public async Task<List<Loot>> GetLootDrops(int piles)
        {
            var g = await LootService.BuildLootProcessorService();
            var m = g.Execute(piles);

            return m;
        }

        [HttpGet]
        [Route("relic")]
        public async Task<Relic> GetRelic()
        {
            var s = await RelicService.BuildRelicLoaderService();
            var r = s.Execute();

            return r;
        }

        [HttpGet]
        [Route("shield")]
        public async Task<Shield> GetShield(int level)
        {
            var r = await ShieldService.BuildShieldLoaderService();
            var s = r.Execute(level);

            return s;
        }

        [HttpGet]
        [Route("grenade")]
        public async Task<Grenade> GetGrenade(int level)
        {
            var r = await GrenadeService.BuildGrenadeLoaderService();
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
        public async Task<Grenade> GetTrauma()
        {
            throw new NotImplementedException();
        }
    }
}