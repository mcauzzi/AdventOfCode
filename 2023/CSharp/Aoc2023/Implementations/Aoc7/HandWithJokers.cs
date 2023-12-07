namespace Implementations.Aoc7;

public class HandWithJokers : Hand
{
    public HandWithJokers(string str) : base(str)
    {
    }

    protected override HandType CalculateType()
    {
        if (Cards.All(x => x == 0))
        {
            return HandType.FiveOfAKind;
        }
        var cardGroups = Cards.Where(x=>x!=0).GroupBy(x => x)
                              .Select(x => new
                                           {
                                               Count =
                                                   x.Key == 0 ? x.Count() : x.Count() + Cards.Count(x => x == 0),
                                               CardValue = x.Key
                                           })
                              .ToList();
       
        return cardGroups.Count switch
               {
                   1 => HandType.FiveOfAKind,
                   2 => cardGroups.Any(x => x.Count == 4) ? HandType.FourOfAKind : HandType.FullHouse,
                   3 => cardGroups.Any(x => x.Count == 3) ? HandType.ThreeOfAKind : HandType.TwoPair,
                   4 => HandType.OnePair,
                   _ => HandType.HighCard
               };
    }

    protected override int CharToCardValue(char ch) =>
        ch switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => 0,
            'T' => 10,
            _   => throw new Exception()
        };
}