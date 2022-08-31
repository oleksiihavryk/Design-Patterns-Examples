namespace CreatingPatterns.Singleton;

public class CollectionIsNotExistInDatabaseException : Exception
{
    public CollectionIsNotExistInDatabaseException(string? message = null)
        :this (message, null)
    {
    }
    public CollectionIsNotExistInDatabaseException(
        string? message, 
        Exception? inner = null)
        : base(message, inner)
    {
    }
}