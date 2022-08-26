public class DiceService
{
    private static Random _random = new Random();

    public int Roll(DiceType diceType)
    {
        return _random.Next(1, Convert.ToInt32(diceType));
    }
}
public enum DiceType
{
    D4 = 5,
    D6 = 7,
    D8 = 9,
    D10 = 11,
    D12 = 13,
    D20 = 21,
    D100 = 101,
    Relic = 41 // i hate this. not feeling like dealing with math right now.
}
