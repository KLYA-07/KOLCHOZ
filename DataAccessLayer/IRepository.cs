namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject, new()
    {
        void Create(T obj);
        IEnumerable<T> ReadAll();
        T ReadByID(int id);
        void Update(T obj);
        void Delete(T obj);
    }
}