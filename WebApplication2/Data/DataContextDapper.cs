using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplication2.Data
{
    public class DataContextDapper
    {
        private readonly IConfiguration _confing;

        public DataContextDapper(IConfiguration confing)
        {
            _confing = confing;
        }

        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_confing.GetConnectionString("DefaultConnetion"));

            return dbConnection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_confing.GetConnectionString("DefaultConnetion"));
            
            return dbConnection.QuerySingle<T>(sql);
        }

        public bool Execute(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_confing.GetConnectionString("DefaultConnetion"));

            return dbConnection.Execute(sql) > 0;
        }
    }
}
