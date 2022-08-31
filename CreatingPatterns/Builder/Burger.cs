using System.Text;

namespace CreatingPatterns.Builder;
public class Burger : IBurger
{
    public List<BurgerPart> Parts = new List<BurgerPart>();
    public Ingredient Ingredients { get; set; }
    public Sauce Sauces { get; set; }
    
    public decimal TotalCost => Parts.Sum(el => el.Cost);

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("-------------------------");
        sb.AppendLine($"  Total cost: {TotalCost}");
        sb.AppendLine("  Total elements:");
        foreach (var p in Parts)
            sb.AppendLine("  1." + p);
        sb.AppendLine("-------------------------");

        return sb.ToString();
    }

}