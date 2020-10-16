using Sample.DB;
using System.Data;
using System.Data.SqlClient;

namespace Sample.Helper
{
    public class ConnectionHelper
    {
        /// <summary>
        /// Gets the open connection.
        /// </summary>
        /// <returns></returns>
        public static IDbConnection GetOpenConnection()
        {
            IDbConnection connection;
            connection = new SqlConnection(@"Data Source=.\SQLEXPRESS2017;Initial Catalog=VGroupHolding;User ID=sa;Password=test@123");
            DapperExtensions.SetDialect(DapperExtensions.Dialect.SQLServer);

            connection.Open();
            return connection;
        }
    }
}
