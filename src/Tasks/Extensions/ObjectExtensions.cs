using Newtonsoft.Json;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
namespace Tasks.Extensions;

public static class ObjectExtensions
{
    /// <summary>
    /// Perform a deep Copy of the object, using Json as a serialisation method.
    /// </summary>
    /// <typeparam name="T">The type of object being copied.</typeparam>
    /// <param name="source">The object instance to copy.</param>
    /// <returns>A deep copy of the given object, or the default value of T if the source is null.</returns>
    public static T? DeepCopy<T>(this T? source) where T : class
    {
        // Don't serialize a null object, simply return the default for that object
        if (source == null)
            return default;
        
        return ReferenceEquals(source, null) 
            ? default 
            : JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
    }   
}