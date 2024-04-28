using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace eShop.Infrastructure.Data;

public class DbConnection
{
    public SqlConnection GetConnection()
    {
        var conn = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("eShop");

        return new SqlConnection(conn);
    }
}