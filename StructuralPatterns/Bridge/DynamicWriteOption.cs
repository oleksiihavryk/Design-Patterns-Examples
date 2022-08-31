namespace StructuralPatterns.Bridge;

public class DynamicWriteOption : IWriteOptionBridge
{
    public string ListStartModifier { get; set; } 
    public string ListEndModifier { get; set; } 
    public string ElementStartModifier { get; set; } 
    public string ElementEndModifier { get; set; } 

    public DynamicWriteOption()
        : this(
            listStartModifier: string.Empty,
            listEndModifier: string.Empty,
            elementEndModifier: string.Empty,
            elementStartModifier: string.Empty)
    {
    }

    public DynamicWriteOption(
        string listStartModifier,
        string listEndModifier, 
        string elementStartModifier,
        string elementEndModifier)
    {
        ListStartModifier = listStartModifier;
        ListEndModifier = listEndModifier;
        ElementStartModifier = elementStartModifier;
        ElementEndModifier = elementEndModifier;
    }
}