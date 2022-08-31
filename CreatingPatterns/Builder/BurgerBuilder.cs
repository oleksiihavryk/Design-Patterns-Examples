using CreatingPatterns.Builder.Extensions;

namespace CreatingPatterns.Builder;
public class BurgerBuilder : IBurgerBuilder
{
    private Burger _burger;

    public BurgerBuilder()
        :this (new Burger())
    {
    }
    public BurgerBuilder(Burger burger)
    {
        _burger = burger;
    }

    public IBurgerBuilder AddTartarSauce(int howMuch)
    {
        AddSauce(
            sauce: Sauce.Tartar, 
            modifier: 0.5m, 
            howMuch);

        return this;
    }
    public IBurgerBuilder AddHotSauce(int howMuch)
    {
        AddSauce(
            sauce: Sauce.Hot,
            modifier: 0.5m,
            howMuch);

        return this;
    }
    public IBurgerBuilder AddTacoSauce(int howMuch)
    {
        AddSauce(
            sauce: Sauce.Taco,
            modifier: 0.5m,
            howMuch);

        return this;
    }
    public IBurgerBuilder AddBarbecueSauce(int howMuch)
    {
        AddSauce(
            sauce: Sauce.Barbecue,
            modifier: 0.5m,
            howMuch);

        return this;
    }
    public IBurgerBuilder AddCheese(int howMuch)
    {
        AddIngredient(
            ingredient: Ingredient.Cheese,
            modifier: 10,
            measure: "slice",
            howMuch);

        return this;
    }
    public IBurgerBuilder AddTomatoes(int howMuch)
    {
        AddIngredient(
            ingredient: Ingredient.Tomato,
            modifier: 10,
            measure: "circles",
            howMuch);

        return this;
    }
    public IBurgerBuilder AddBeef(int howMuch)
    {
        AddIngredient(
            ingredient: Ingredient.Beef,
            modifier: 40m,
            measure: "part",
            howMuch);

        return this;
    }
    public IBurgerBuilder AddPork(int howMuch)
    {
        AddIngredient(
            ingredient: Ingredient.Pork,
            modifier: 40m,
            measure: "part",
            howMuch);

        return this;
    }
    public IBurgerBuilder AddCucumbers(int howMuch)
    {
        AddIngredient(
            ingredient: Ingredient.Cucumber,
            modifier: 10,
            measure: "circles",
            howMuch);

        return this;
    }
    public IBurgerBuilder AddOnions(int howMuch)
    {
        AddIngredient(
            ingredient: Ingredient.Onions,
            modifier: 5,
            measure: "circles",
            howMuch);

        return this;
    }
    public Burger Build()
    {
        return _burger;
    }

    private void AddSauce(
        Sauce sauce, 
        decimal modifier,
        int howMuch)
    {
        if (!_burger.Sauces.Includes(sauce))
            _burger.Sauces = _burger.Sauces | sauce;

        decimal cost = howMuch * modifier;

        _burger.Parts.Add(
            new SauceBurgerPart(cost, sauce, howMuch));
    }
    private void AddIngredient(
        Ingredient ingredient,
        decimal modifier,
        string measure,
        int howMuch)
    {
        if (!_burger.Ingredients.Includes(ingredient))
            _burger.Ingredients = _burger.Ingredients | ingredient;

        decimal cost = howMuch * modifier;

        _burger.Parts.Add(
            new IngredientBurgerPart(ingredient, measure, howMuch, cost));
    }

    public static implicit operator Burger(BurgerBuilder bb)
    {
        return bb.Build();
    }
}