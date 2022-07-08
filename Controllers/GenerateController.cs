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
            var g = await LootProcessorService.BuildLootProcessorService();
            var m = g.Execute(piles);

            return m;
        }

        [HttpGet]
        [Route("relic")]
        public async Task<Relic> GetRelic()
        {
            var s = await RelicLoaderService.BuildRelicLoaderService();
            var r = s.Execute();

            return r;
        }

        [HttpGet]
        [Route("shield")]
        public async Task<Shield> GetShield(int level){
            var r = await ShieldLoaderService.BuildShieldLoaderService();
            var s = r.Execute(level);

            return s;
        }        

        [HttpGet]
        [Route("grenade")]
        public async Task<Grenade> GetGrenade(int level){
            var r = await GrenadeLoaderService.BuildGrenadeLoaderService();
            var s = r.Execute(level);

            return s;
        }
    }
}