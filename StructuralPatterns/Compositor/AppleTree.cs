using System.Collections;

namespace StructuralPatterns.Compositor;
public class AppleTree : IAppleStorageCompositor
{
    public List<Apple> Apples { get; set; }
    public int AppleCount => Apples.Count;

    public AppleTree()
    {
        Apples = new List<Apple>();

        Random r = new Random();
        for (int i = 0; i < r.Next(10, 20); i++)
        {
            var c = (AppleColor)r.Next(0, 2);
            var s = (AppleSize) r.Next(0, 2);
            Apples.Add(new Apple(
                color: c, 
                size: s));
        }
    }

    public IEnumerator<IAppleStorageCompositor> GetEnumerator() => Apples.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

}