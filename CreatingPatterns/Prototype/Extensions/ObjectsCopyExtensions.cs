using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CreatingPatterns.Prototype.Extensions;
public static class ObjectsCopyExtensions
{
    public static T DeepCopy<T>(this T obj)
    {
        var str = JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
        var newObj = JsonConvert.DeserializeObject<T>(str) ??
                     throw new SerializationException(
                         "Error has occurred from json serialization of object.");
        return newObj;
    }
    public static T ShallowCopy<T>(this T obj)
        where T : ICloneable => (T)obj.Clone();
    
}