using System.Collections;

namespace StructuralPatterns.Compositor;
public class Apple : IAppleStorageCompositor
{
    public const AppleColor DefaultColor = AppleColor.Red;
    public const AppleSize DefaultSize = AppleSize.Medium;

    public AppleColor Color { get; set; }
    public AppleSize Size { get; set; }
    public int AppleCount => 1;

    public Apple()
        : this (DefaultColor, DefaultSize)
    {
    }
    public Apple(
        AppleColor color,
        AppleSize size)
    {
        Color = color;
        Size = size;
    }

    public IEnumerator<IAppleStorageCompositor> GetEnumerator()
    {
        yield return this;
    }
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}