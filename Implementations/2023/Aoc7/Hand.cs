using Implementations.Helpers;

namespace Implementations._2023.Aoc7;

public class Hand : IComparable<Hand>, IComparable
{
    protected List<int> Cards { get; init; } = new();
    protected HandType  Type  { get; init; }

    public override string ToString()
    {
        return $"{nameof(Cards)}: {string.Join(',',Cards)}, {nameof(Type)}: {Type}";
    }

    public Hand(string str)
    {
        foreach (var ch in str)
        {
            Cards.Add(ch.IsNumber() ? int.Parse(ch.ToString()) : CharToCardValue(ch));
        }

        Type = CalculateType();
    }

    public int CompareTo(Hand? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        if (Type != other.Type)
        {
            return Type - other.Type;
        }

        for (int i = 0; i < Cards.Count; i++)
        {
            if (Cards[i] != other.Cards[i])
            {
                return Cards[i] - other.Cards[i];
            }
        }

        return 0;
    }

    public int CompareTo(object? obj)
    {
        if (ReferenceEquals(null, obj)) return 1;
        if (ReferenceEquals(this, obj)) return 0;
        return obj is Hand other
                   ? CompareTo(other)
                   : throw new ArgumentException($"Object must be of type {nameof(Hand)}");
    }

    public static bool operator <(Hand? left, Hand? right)
    {
        return Comparer<Hand>.Default.Compare(left, right) < 0;
    }

    public static bool operator >(Hand? left, Hand? right)
    {
        return Comparer<Hand>.Default.Compare(left, right) > 0;
    }

    public static bool operator <=(Hand? left, Hand? right)
    {
        return Comparer<Hand>.Default.Compare(left, right) <= 0;
    }

    public static bool operator >=(Hand? left, Hand? right)
    {
        return Comparer<Hand>.Default.Compare(left, right) >= 0;
    }

    protected virtual HandType CalculateType()
    {
        var cardGroups = Cards.GroupBy(x => x)
                              .Select(x => new
                                           {
                                               Count     = x.Key==0?x.Count():x.Count()+Cards.Count(x=>x==0),
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

    protected virtual int CharToCardValue(char ch) =>
        ch switch
        {
            'A' => 14,
            'K' => 13,
            'Q' => 12,
            'J' => 11,
            'T' => 10,
            _   => throw new Exception()
        };

    protected enum HandType
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind
    }
}