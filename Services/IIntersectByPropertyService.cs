namespace PCBuilder.Services
{
    public interface IIntersectByPropertyService
    {
        public List<T> GetIntersectionByProperty<T, TKey>(Func<T, TKey> keySelector, params List<T>[] lists);
    }
}
