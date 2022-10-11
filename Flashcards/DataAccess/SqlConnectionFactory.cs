using Microsoft.Data.SqlClient;

namespace DataAccess;

public class SqlConnectionFactory
{
    private const string _connectionString = $"Server=tcp:220926net.database.windows.net,1433;Initial Catalog=FlashcardsDB;Persist Security Info=False;User ID=flashcard-admin;Password={Secrets.password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}