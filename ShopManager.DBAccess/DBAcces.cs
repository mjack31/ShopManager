using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.DBAccess
{
    internal class DBAcces
    {
        private string GetConnectionString(string name)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return connectionString;
        }

        public IEnumerable<T> LoadDataFromDB<T, U>(string storedProcedure, U parameters, string connectionString)
        {
            using (var dbConnection = new SqlConnection(GetConnectionString(connectionString)))
            {
                var data = dbConnection.Query<T>(storedProcedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
                return data;
            }
        }

        //public void SaveDataToDB<T, U>(string storedProcedure, U parameters, string connectionString)
        //{
        //    using (var dbConnection = new SqlConnection(GetConnectionString(connectionString)))
        //    {
        //        var data = dbConnection.Query<T>(storedProcedure, parameters/*, commandType: System.Data.CommandType.StoredProcedure*/);
        //        return data;
        //    }
        //}
    }
}
