namespace StructuralPatterns.Decorator;

public interface ITestDataProvider
{
    IEnumerable<int> GetIntegers(
        int count, 
        int min = 0, 
        int max = 100);
    IEnumerable<string> GetStrings(
        int count, 
        int stringLength,
        char[]? defaultLetters = null);
}