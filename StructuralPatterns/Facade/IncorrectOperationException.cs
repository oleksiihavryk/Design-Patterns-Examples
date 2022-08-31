namespace StructuralPatterns.Facade;
internal class IncorrectOperationException : Exception
{
    public override string Message => base.Message ?? 
                                      "Error while trying to create operation";

    public IncorrectOperationException(string? message = null) 
        : base(message)
    {
    }
    public IncorrectOperationException(string? message, Exception? inner = null)
        : base(message, inner)
    {
    }
}