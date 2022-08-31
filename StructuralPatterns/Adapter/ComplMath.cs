namespace StructuralPatterns.Adapter;

public class ComplMath : IComplMath
{
    private readonly ISimpleMath _simpleMath;

    public ComplMath(ISimpleMath simpleMath)
    {
        _simpleMath = simpleMath;
    }

    public decimal Multiply(decimal n, decimal arr)
    {
        decimal sum = n;
        while (arr-- >= 2)
            sum = _simpleMath.Add(sum, n);
        return sum;
    }
    public decimal Divide(decimal n, decimal arr)
    {
        decimal sum = 0;
        decimal num = _simpleMath.Subtract(n, arr);
        while (num >= 0)
        {
            sum++;
            num = _simpleMath.Subtract(num, arr);
        }
        return sum;
    }
}