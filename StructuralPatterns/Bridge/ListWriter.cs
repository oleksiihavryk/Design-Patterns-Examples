namespace StructuralPatterns.Bridge;
public class ListWriter<T>
{
    private readonly IWriteOptionBridge _writeOption;
    
    public List<T> List { get; set; }

    public ListWriter(IWriteOptionBridge writeOption)
        : this (writeOption, new List<T>())
    {
        _writeOption = writeOption;
    }
    public ListWriter(
        IWriteOptionBridge writeOption,
        List<T> list)
    {
        _writeOption = writeOption;
        List = list;
    }

    public string GetElementString(T el)
        => _writeOption.ElementStartModifier + 
           el.ToString() +              
           _writeOption.ElementEndModifier;
    public string GetListString()
        => _writeOption.ListStartModifier +
           string.Join("", List.Select(el => GetElementString(el))) +
           _writeOption.ListEndModifier;

    public override string ToString() => GetListString();
}