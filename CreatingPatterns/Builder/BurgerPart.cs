namespace CreatingPatterns.Builder;

public abstract class BurgerPart
{
    public decimal Cost { get; set; }

    protected BurgerPart(decimal cost)
    {
        Cost = cost;
    }
}