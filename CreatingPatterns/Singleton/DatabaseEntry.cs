namespace CreatingPatterns.Singleton;

public record DatabaseEntry<T>(Guid Id, T Value);