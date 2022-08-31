namespace CreatingPatterns.Builder;

[Flags]
public enum Ingredient
{
    Cheese = 0x0001,
    Tomato = 0x0002,
    Cucumber = 0x0004,
    Beef = 0x0010,
    Pork = 0x0020,
    Onions = 0x0040
}