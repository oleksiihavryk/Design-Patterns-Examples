namespace CreatingPatterns.Builder;

public class IngredientBurgerPart : BurgerPart
{
    public const decimal DefaultCost = 20;

    public Ingredient Ingredient { get; }
    public string Measure { get; }
    public int Count { get; }

    public IngredientBurgerPart(
        Ingredient ingredient, 
        string measure, 
        int count) 
        : this (ingredient, measure, count, DefaultCost)
    {
    }
    public IngredientBurgerPart(
        Ingredient ingredient, 
        string measure,
        int count,
        decimal cost)
        : base(cost)
    {
        Ingredient = ingredient;
        Measure = measure;
        Count = count;
    }

    public override string ToString()
    {
        return $"{Ingredient} - {Count}{Measure} by {Cost}cents";
    }
}