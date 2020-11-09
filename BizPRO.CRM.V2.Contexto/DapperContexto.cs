using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BizPRO.CRM.V2.Contexto.Interfaces;

namespace BizPRO.CRM.V2.Contexto
{
    public class DapperContexto : IDapperContexto
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public DapperContexto()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
        }
    }
}
