namespace StructuralPatterns.Decorator;
public class ImprovedTestDataProviderDecorator : IImprovedTestDataProvider
{
    protected readonly ITestDataProvider _testDataProvider;

    public ImprovedTestDataProviderDecorator(ITestDataProvider testDataProvider)
    {
        _testDataProvider = testDataProvider;
    }


    public IEnumerable<int> GetIntegers(
        int count, 
        int min = 0,
        int max = 100)
        => _testDataProvider.GetIntegers(count, min, max);
    public IEnumerable<string> GetStrings(
        int count, 
        int stringLength,
        char[]? defaultLetters = null)
        => _testDataProvider.GetStrings(count, stringLength, defaultLetters);
    public IEnumerable<bool> GetBooleans(int count)
        => _testDataProvider
            .GetIntegers(count, 0, 1)
            .Select(i => Convert.ToBoolean(i));
    public IEnumerable<char> GetChars(int count, char[]? defaultLetters = null)
        => _testDataProvider
            .GetStrings(count,
                stringLength: 1,
                defaultLetters: defaultLetters ?? TestDataProvider.DefaultLetters)
            .Select(c => c.ToCharArray()[0]);
}