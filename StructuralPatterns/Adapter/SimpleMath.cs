namespace StructuralPatterns.Adapter;
public class SimpleMath : ISimpleMath
{
    public decimal Add(decimal from, decimal n)
        => from + n;
    public decimal Subtract(decimal from, decimal n) 
        => from - n;
}