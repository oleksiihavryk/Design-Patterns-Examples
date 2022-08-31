namespace CreatingPatterns.Singleton;

public class DeletingObjectFromDatabaseException : Exception
{
    public DeletingObjectFromDatabaseException(string? message = null)
        :this (message, null)
    {
    }
    public DeletingObjectFromDatabaseException(
        string? message,
        Exception? inner = null)
        :base(message, inner)
    {
    }
}