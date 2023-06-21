namespace CloudBeat.Framework
{
    public static class ExtensionMethods
    {
        public static IEnumerable<Q> MapRecords<T, Q>(this IEnumerable<T> collection, Func<T, Q> mapper)
        {
            if (collection.IsNullOrEmpty())
                throw new NullReferenceException();

            List<Q> result = new List<Q>();
            foreach (T record in collection)
            {
                result.Add(mapper(record));
            }

            return result;
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || collection.Count() == 0;
        }
    }
}