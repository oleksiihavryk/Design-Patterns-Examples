namespace StructuralPatterns.Decorator;
public interface IImprovedTestDataProvider : ITestDataProvider
{
    IEnumerable<bool> GetBooleans(int count);
    IEnumerable<char> GetChars(int count, char[]? defaultLetters = null);
}