using System.Collections;
using Microsoft.VisualBasic;

namespace CreatingPatterns.Singleton;
public class DatabaseSingleton
{
    private readonly List<IDictionary> _temp;

    public static DatabaseSingleton Instance { get; } = new DatabaseSingleton();

    private DatabaseSingleton()
    {
        _temp = new List<IDictionary>();
    }

    public DatabaseEntry<T> Add<T>(T obj)
    {
        IDictionary<Guid, T> dict;

        if (IsExist<T>())
        {
            dict = FindCollectionWithThisType<T>();
        }
        else
        {
            dict = new Dictionary<Guid, T>();
            _temp.Add((IDictionary)dict);
        }

        var guid = Guid.NewGuid();
        dict.Add(guid, obj);

        var rec = new DatabaseEntry<T>(guid, obj);

        return rec;
    }
    public void Remove<T>(Guid guid)
    {
        if (IsExist<T>())
        {
            var dict = FindCollectionWithThisType<T>();
            dict.Remove(guid);

            if (!dict.Any() && !_temp.Remove((IDictionary)dict))
            {
                throw new DeletingObjectFromDatabaseException();
            }
        }

        throw new CollectionIsNotExistInDatabaseException(
            $"Objects collection of type {typeof(T).FullName} is " +
            $"does not exist in database.");
    }
    public T GetById<T>(Guid guid)
    {
        if (IsExist<T>())
        {
            var dict = FindCollectionWithThisType<T>();
            var obj = dict[guid];

            return obj;
        }

        throw new CollectionIsNotExistInDatabaseException(
            $"Objects collection of type {typeof(T).FullName} is " +
            $"does not exist in database.");
    }
    public IEnumerable<T> GetAllOfType<T>()
    {
        if (IsExist<T>())
        {
            var dict = FindCollectionWithThisType<T>();
            return dict.Values;
        }

        throw new CollectionIsNotExistInDatabaseException(
            $"Objects collection of type {typeof(T).FullName} is " +
            $"does not exist in database.");
    }
    public IEnumerable<(T, Guid)> GetAllOfTypeWithId<T>()
    {
        if (IsExist<T>())
        {
            var dict = FindCollectionWithThisType<T>();
            return dict.Select(p => (p.Value, p.Key));
        }

        throw new CollectionIsNotExistInDatabaseException(
            $"Objects collection of type {typeof(T).FullName} is " +
            $"does not exist in database.");
    }

    private IDictionary<Guid, T> FindCollectionWithThisType<T>()
        => (_temp.Find(ExistPredicate<T>) as
               IDictionary<Guid, T>) ?? 
           throw new CollectionIsNotExistInDatabaseException();
    private bool IsExist<T>()
        => _temp.Exists(ExistPredicate<T>);
    private bool ExistPredicate<T>(IDictionary d)
        => d.Values is ICollection<T>;
}