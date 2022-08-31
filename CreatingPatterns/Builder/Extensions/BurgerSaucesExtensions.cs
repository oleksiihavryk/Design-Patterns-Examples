namespace CreatingPatterns.Builder.Extensions;

public static class BurgerSaucesExtensions
{
    public static bool Includes(this Sauce sauces, Sauce sauce)
        => sauces.HasFlag(sauce);
}