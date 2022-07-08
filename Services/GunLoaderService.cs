namespace BunkerGen.Services
{
    public class GunLoaderService
    {
        private readonly DiceService DiceService;
        private GunLoaderService()
        {

            DiceService = new DiceService();
        }
    }
}