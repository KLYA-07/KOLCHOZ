using Model;

namespace DataAccessLayer
{
    public interface IRepository<T> where T : IDomainObject, new()
    {
        /// <summary>
        /// Создание сущности и добавление в базу данных
        /// </summary>
        /// <param name="obj">Объект сущности</param>
        void Create(T obj);

        /// <summary>
        /// Чтение всех сущностей из базы данных
        /// </summary>
        /// <returns>Тип сущности</returns>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// Чтение сущности по ID
        /// </summary>
        /// <param name="id">ID сущности</param>
        /// <returns>Объект сущности</returns>
        T ReadByID(int id);

        /// <summary>
        /// Обновление сущности в базе данных
        /// </summary>
        /// <param name="obj">Объект обновленной сущности </param>
        void Update(T obj);

        /// <summary>
        /// Удаление сущности из базы данных
        /// </summary>
        /// <param name="obj">Объект сущности</param>
        void Delete(T obj);
    }
}