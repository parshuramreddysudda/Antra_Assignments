using System.Data;
using Dapper;
using eShop.Core;
using eShop.Core.Interfaces;
using eShop.Infrastructure.Data;

namespace eShop.Infrastructure.Repositories;

public class ReviewRepository : IRepository<Review>
{
    DbConnection _dbConnection = new DbConnection();
    public int Insert(Review obj)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return conn.Execute("INSERT INTO Reviews VALUES (@id,@ProductId,@PersonName,@ReviewInformation)", obj);

    }

    public int DeleteById(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return conn.Execute("DELETE FROM Reviews where id = @id", id);
    }

    public int Update(int obj)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return conn.Execute("UPDATE Reviews SET id=@id ,ProductId=@ProductId,PersonName=@PersonName,ReviewInformation=@ReviewInformation Where ID=@id)", obj);
    }

    public IEnumerable<Review> GetAll()
    {
        IDbConnection conn = _dbConnection.GetConnection();
       // return conn.Query<>()
       return null;
    }

    public Review GetById(int id)
    {
        IDbConnection conn = _dbConnection.GetConnection();
        return conn.Query("Select Id, ProductID,PersonName,ReviewInformation where id=@id", id)<Review>;
    }
}