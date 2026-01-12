using System.Data;
using System.Data.SqlClient;

namespace TaskManager.Infrastructure.Persistence
{
    public class DbConnectionFactory
    {
        private readonly string _connectionSting;

        public DbConnectionFactory(string connectionSting)
        {
            _connectionSting = connectionSting;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionSting);
    }
}
