using System.Data;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace RestWrapper.Core.CrossCuttingConcerns.Logging.DatabaseLoggers
{
    public class RequestDBLogger : DbLoggerBase
    {
        public RequestDBLogger(IConfiguration configuration) : base(configuration){}

        public void Info(int callId, string logMessage)
        {
            using (_connection = new OracleConnection(_connectionString))
            {
                using (_command = _connection.CreateCommand())
                {
                    _connection.Open();
                    _command.BindByName = true;
                    _command.CommandText = "insert into \"Requests\"(\"ParentId\", \"Value\", \"InsertDate\") values (:callId, :logMessage, CURRENT_TIMESTAMP)";
                    OracleParameter callIdParameter = new OracleParameter("callId", OracleDbType.Int32, callId, ParameterDirection.Input);
                    OracleParameter logMessageParameter = new OracleParameter("logMessage", OracleDbType.Clob, logMessage, ParameterDirection.Input);
                    _command.Parameters.Add(callIdParameter);
                    _command.Parameters.Add(logMessageParameter);

                    _command.ExecuteNonQuery();
                }
            }
        }
    }
}
