using System.Collections.Generic;

namespace BookStore.Api.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void AddIfNotNull<T>(this List<T> source, T item)
        {
            if (item != null)            
                source.Add(item);            
        }
    }
}
