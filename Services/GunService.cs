namespace BunkerGen.Services
{
    public class GunService
    {


        private readonly DiceService DiceService;
        private GunService(DiceService diceService)
        {

            DiceService = diceService;
        }
    }
}