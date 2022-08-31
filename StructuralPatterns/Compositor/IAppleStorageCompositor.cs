namespace StructuralPatterns.Compositor;

public interface IAppleStorageCompositor : IEnumerable<IAppleStorageCompositor>
{
    public int AppleCount { get; }
}