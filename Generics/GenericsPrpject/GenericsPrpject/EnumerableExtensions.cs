namespace GenericsPrpject
{
    public static class EnumerableExtensions
    {
        // R1
        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (pageNumber < 1)
                throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be 1 or greater.");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be 1 or greater.");

            return PageIterator(source, pageNumber, pageSize);
        }

        private static IEnumerable<T> PageIterator<T>(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var skipCount = (pageNumber - 1) * pageSize;
            var current = 0;
            var yielded = 0;

            foreach (var item in source)
            {
                if (current >= skipCount && yielded < pageSize)
                {
                    yield return item;
                    yielded++;

                    if (yielded == pageSize)
                        yield break;
                }

                current++;
            }
        }

        // R2
        public static T? FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
            {
                if (item.Id == id)
                    return item;
            }

            return default;
        }

        // R3
        public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(this IEnumerable<T> source) where T : IHasId
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var dict = new Dictionary<int, T>();

            foreach (var item in source)
            {
                dict.Add(item.Id, item);
            }

            return dict;
        }
    }
}