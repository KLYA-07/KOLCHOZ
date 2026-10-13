using Dapper;
using DataAccessLayer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;
using System.Data;

public class DapperRepository: IRepository<Farmer>
{
    string connectionString = null;
    public DapperRepository(string conn)
    {
        connectionString = conn;
    }
    public void Create(Farmer obj) {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            var sqlQuery = "INSERT INTO Farmers (farmerName, farmerSurname, phoneNumber, finacialCapital, fieldArea, farmAddress, farmType, registrationDate) " +
                "VALUES(@farmerName, @farmerSurname, @phoneNumber, @finacialCapital, @fieldArea, @farmAddress, @farmType, @registrationDate)";
            db.Execute(sqlQuery, obj);

        }
    }
    public IEnumerable<Farmer> ReadAll()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            return connection.Query<Farmer>("SELECT * FROM Farmers").ToList();
        }
    }
    public Farmer ReadByID(int id)
    {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            return db.Query<Farmer>("SELECT * FROM Farmers WHERE Id = @id", new { id }).FirstOrDefault();
        }
    }
    public void Update(Farmer obj) {
        using (IDbConnection db = new SqlConnection(connectionString))
        {
            var sqlQuery = "UPDATE Farmers SET farmerName = @farmerName, farmerSurname = @farmerSurname, phoneNumber = @phoneNumber, finacialCapital = @finacialCapital, " +
                "fieldArea = @fieldArea, farmAddress = @farmAddress, farmType = @farmType, registrationDate = @registrationDate WHERE Id = @id";
            db.Execute(sqlQuery, obj);
        }
    }
    public void Delete(Farmer obj)
    {
        using IDbConnection db = new SqlConnection(connectionString);
        var sqlQuery = "DELETE FROM Farmers WHERE ID = @ID";
        var rows = db.Execute(sqlQuery, new { obj.ID });
        Console.WriteLine($"Удалено строк: {rows}");
    }
}