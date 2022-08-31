namespace StructuralPatterns.Decorator;
public sealed class TestDataProvider : ITestDataProvider
{
    public static readonly char[] DefaultLetters = new char[]
    {
        '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
    };

    public IEnumerable<int> GetIntegers(
        int count,
        int min = 0, 
        int max = 100)
    {
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        if (min <= 0)
            throw new ArgumentOutOfRangeException(nameof(min));

        if (max <= 0)
            throw new ArgumentOutOfRangeException(nameof(max));

        var r = new Random();
        var list = new List<int>();
        while (count --> 0)
            list.Add(r.Next(min, max));
        return list;
    }
    public IEnumerable<string> GetStrings(
        int count, 
        int stringLength, 
        char[]? defaultLetters = null)
    {
        if (defaultLetters == null)
            defaultLetters = DefaultLetters;

        if (stringLength <= 0)
            throw new ArgumentOutOfRangeException(nameof(stringLength));
        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count));

        var r = new Random();
        var list = new List<string>();
        
        while (count --> 0)
        {
            int sl = stringLength;
            var chars = new char[sl];
            for (int i = 0;i < sl; i++)
                chars[i] = defaultLetters[r.Next(0, defaultLetters.Length)];
            list.Add(new string(chars));
        }

        return list;
    }
}