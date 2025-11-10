namespace Shop;

public static class UserUtils
{
    private const int InclusiveRangeCorrection = 1;
    private const int PercentMinInclusive = 1;
    private const int PercentMaxExclusive = 101;
    private const int MinRandomValue = 0;
    private const int MinPercentValue = 0;
    private const int MaxPercentValue = 100;

    private static readonly Random s_random = new Random();

    public static int GenerateRandomNumber(int min, int max)
    {
        return s_random.Next(min, max + InclusiveRangeCorrection);
    }

    public static int GenerateRandomNumber(int maxExclusive)
    {
        return s_random.Next(MinRandomValue, maxExclusive + InclusiveRangeCorrection);
    }

    public static bool TryGetRandomChance(int percentChance)
    {
        if (percentChance < MinPercentValue)
            percentChance = MinPercentValue;
        
        if (percentChance > MaxPercentValue)
            percentChance = MaxPercentValue;
        
        int chance = s_random.Next(PercentMinInclusive, PercentMaxExclusive);
        
        return chance <= percentChance;
    }
}