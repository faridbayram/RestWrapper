using System;
using System.Configuration;
using System.Text;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace RestWrapper.Core.CrossCuttingConcerns.Logging.DatabaseLoggers
{
    public class DatabaseLogger
    {
        private readonly string _connectionString;

        public DatabaseLogger(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionStringOracle");
        }

        public string Add()
        {
            StringBuilder sb = new StringBuilder();

            using (OracleConnection conStr = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = conStr.CreateCommand())
                {
                    conStr.Open();
                    cmd.BindByName = true;

                    cmd.CommandText = "select * from \"Calls\"";
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        sb.AppendLine($"{reader.GetString(0)} - {reader.GetString(1)}");

                    return sb.ToString();
                }
            }
        }
    }
}
