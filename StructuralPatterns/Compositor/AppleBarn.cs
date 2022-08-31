using System.Collections;

namespace StructuralPatterns.Compositor;
public class AppleBarn : IAppleStorageCompositor
{
    public int AppleCount => Storage.Sum(e => e.AppleCount);
    public List<IAppleStorageCompositor> Storage { get; set; }

    public AppleBarn()
        : this (new List<IAppleStorageCompositor>())
    {
    }
    public AppleBarn(List<IAppleStorageCompositor> storage)
    {
        Storage = storage;
    }

    public IEnumerator<IAppleStorageCompositor> GetEnumerator() => Storage.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}