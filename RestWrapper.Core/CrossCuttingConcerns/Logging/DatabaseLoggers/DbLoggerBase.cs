using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace RestWrapper.Core.CrossCuttingConcerns.Logging.DatabaseLoggers
{
    public class DbLoggerBase
    {
        protected readonly string _connectionString;
        protected OracleConnection _connection;
        protected OracleCommand _command;

        public DbLoggerBase(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionStringOracle");
        }
    }
}
