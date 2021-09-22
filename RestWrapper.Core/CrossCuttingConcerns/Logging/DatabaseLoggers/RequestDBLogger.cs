using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace RestWrapper.Core.CrossCuttingConcerns.Logging.DatabaseLoggers
{
    public class RequestDBLogger
    {
        private readonly string _connectionString;
        private OracleConnection _connection;
        private OracleCommand _command;


        public RequestDBLogger(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionStringOracle");
        }

        public void Info(int callId, string logMessage)
        {
            StringBuilder sb = new StringBuilder();

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
