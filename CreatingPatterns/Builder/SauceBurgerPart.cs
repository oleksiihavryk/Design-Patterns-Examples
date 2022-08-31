namespace CreatingPatterns.Builder;

public class SauceBurgerPart : BurgerPart
{
    public const decimal DefaultCost = 10;

    public Sauce Sauce { get; }
    public int Count { get; }

    public SauceBurgerPart(
        Sauce sauce,
        int count)
        : this(DefaultCost, sauce, count)
    {
        Sauce = sauce;
        Count = count;
    }
    public SauceBurgerPart(
        decimal cost, 
        Sauce sauce, 
        int count) : base(cost)
    {
        Sauce = sauce;
        Count = count;
    }

    public override string ToString()
    {
        return $"{Sauce} - {Count}ml by {Cost}cents";
    }
}