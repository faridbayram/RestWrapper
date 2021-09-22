using System;
using System.Data;
using System.Text;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace RestWrapper.Core.CrossCuttingConcerns.Logging.DatabaseLoggers
{
    public class CallDBLogger : DbLoggerBase
    {
        public CallDBLogger(IConfiguration configuration) : base(configuration) {}

        public int Info()
        {
            using (_connection = new OracleConnection(_connectionString))
            {
                using (_command = _connection.CreateCommand())
                {
                    _connection.Open();
                    _command.BindByName = true;
                    _command.CommandText = "insert into \"Calls\"(\"InsertDate\")  values (CURRENT_TIMESTAMP) returning \"Id\" into :returnValue";
                    OracleParameter op = new OracleParameter("returnValue", OracleDbType.Int32, ParameterDirection.ReturnValue);
                    _command.Parameters.Add(op);

                    _command.ExecuteNonQuery();
                    var result = Convert.ToInt32(op.Value.ToString());
                    return result;
                }
            }
        }
    }
}
