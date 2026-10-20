using Dapper;
using DataAccessLayer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using System.Data;

/// <summary>
/// Репозиторий для работы с сущностью Farmer.
/// Реализует интерфейс IRepository<Farmer>.
/// Обеспечивает CRUD-операции (создание, чтение, обновление, удаление)
/// для таблицы Farmers в базе данных SQL Server с помощью Dapper.
/// </summary>
public class DapperRepository<T> : IRepository<Farmer>
{
    // Строка подключения к базе данных
    string connectionString = @"Server=DESKTOP-5MBC09Q\MOPSIEZH285;Database=KOLCHOZ;User Id=sa;Password=A17B18!!C19D20;TrustServerCertificate=True;";

    /// <summary>
    /// Конструктор репозитория.
    /// </summary>
    /// <param name="conn">Строка подключения к базе данных SQL Server</param>


    /// <summary>
    /// Создаёт нового фермера в таблице Farmers.
    /// Использует параметризованный SQL-запрос для защиты от SQL-инъекций.
    /// </summary>
    /// <param name="obj">Объект Farmer для добавления</param>
    public void Create(Farmer obj)
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            var sqlQuery = "INSERT INTO Farmers (farmerName, farmerSurname, phoneNumber, finacialCapital, fieldArea, farmAddress, farmType, registrationDate) " +
                "VALUES(@farmerName, @farmerSurname, @phoneNumber, @finacialCapital, @fieldArea, @farmAddress, @farmType, @registrationDate)";
            db.Execute(sqlQuery, obj);
        }
    }

    /// <summary>
    /// Возвращает список всех фермеров из таблицы Farmers.
    /// </summary>
    /// <returns>Коллекция объектов Farmer</returns>
    public IEnumerable<Farmer> ReadAll()
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<Farmer>("SELECT * FROM Farmers").ToList();
        }
    }

    /// <summary>
    /// Возвращает одного фермера по его уникальному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор фермера</param>
    /// <returns>Объект Farmer или null, если не найден</returns>
    public Farmer ReadByID(int id)
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<Farmer>("SELECT * FROM Farmers WHERE Id = @id", new { id }).FirstOrDefault();
        }
    }

    /// <summary>
    /// Обновляет данные существующего фермера в таблице Farmers.
    /// Поиск выполняется по полю Id.
    /// </summary>
    /// <param name="obj">Объект Farmer с обновлёнными данными</param>
    public void Update(Farmer obj)
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            var sqlQuery = "UPDATE Farmers SET farmerName = @farmerName, farmerSurname = @farmerSurname, phoneNumber = @phoneNumber, finacialCapital = @finacialCapital, " +
                "fieldArea = @fieldArea, farmAddress = @farmAddress, farmType = @farmType, registrationDate = @registrationDate WHERE Id = @id";
            db.Execute(sqlQuery, obj);
        }
    }

    /// <summary>
    /// Удаляет фермера из таблицы Farmers по его ID.
    /// Выводит в консоль количество удалённых строк.
    /// </summary>
    /// <param name="obj">Объект Farmer, который нужно удалить</param>
    public void Delete(Farmer obj)
    {
        using IDbConnection db = new SqlConnection(connectionString);
        var sqlQuery = "DELETE FROM Farmers WHERE ID = @ID";
        var rows = db.Execute(sqlQuery, new { obj.ID });
    }
}