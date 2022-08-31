namespace StructuralPatterns.Bridge;

public interface IWriteOptionBridge
{
    string ListStartModifier { get; }
    string ListEndModifier { get; }
    string ElementStartModifier { get; }
    string ElementEndModifier { get; set; }
}