namespace PCBuilder.Services
{
    public class IntersectByPropertyService : IIntersectByPropertyService
    {
        public List<T> GetIntersectionByProperty<T, TKey>(Func<T, TKey> keySelector, params List<T>[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return new List<T>();
            }

            Dictionary<TKey, int> keyCounts = new Dictionary<TKey, int>();
            foreach (List<T> list in lists.Where(l => l.Any()))
            {
                foreach (T item in list)
                {
                    TKey key = keySelector(item);
                    if (keyCounts.ContainsKey(key))
                    {
                        keyCounts[key]++;
                    }
                    else
                    {
                        keyCounts.Add(key, 1);
                    }
                }
            }

            List<TKey> keys = keyCounts.Where(kvp => kvp.Value == lists.Count(l => l.Any())).Select(kvp => kvp.Key).ToList();

            Dictionary<TKey, T> objectMap = new Dictionary<TKey, T>();
            foreach (List<T> list in lists)
            {
                foreach (T item in list)
                {
                    TKey key = keySelector(item);
                    if (keys.Contains(key) && !objectMap.ContainsKey(key))
                    {
                        objectMap.Add(key, item);
                    }
                }
            }
            List<T> result = objectMap.Values.ToList();

            return result;
        }
    }
}
