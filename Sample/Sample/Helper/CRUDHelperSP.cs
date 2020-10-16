using Dapper;
using Sample.DB;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Helper
{
    /// <summary>
    /// https://dapper-tutorial.net/dapper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CRUDHelperSP
    {
        public async Task<int> ExecuteSP(string storedProcedure, object param = null, bool isInsert = false)
        {
            using (var connection = ConnectionHelper.GetOpenConnection())
            {
                if (isInsert)
                {
                    return (await connection.ExecuteScalarAsync<int>(storedProcedure, param, commandType: CommandType.StoredProcedure));
                }
                else
                {
                    return (await connection.ExecuteAsync(storedProcedure, param, commandType: CommandType.StoredProcedure));
                }
            }
        }

        public async Task<IEnumerable<T>> ExecuteGetSP<T>(string storedProcedure, object param = null)
        {
            using (var connection = ConnectionHelper.GetOpenConnection())
            {
                return await connection.QueryAsync<T>(storedProcedure, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
