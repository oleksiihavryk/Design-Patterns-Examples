namespace CreatingPatterns.Builder.Extensions;

public static class BurgerIngredientsExtensions
{
    public static bool Includes(this Ingredient ingredients, Ingredient ingredient)
        => ingredients.HasFlag(ingredient);
}