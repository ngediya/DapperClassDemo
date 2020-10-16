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
    public class CRUDHelper<T>
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T GetById(long id)
        {
            using (var connection = ConnectionHelper.GetOpenConnection())
            {
                return connection.Get<T>(id);
            }
        }

        /// <summary>
        /// Gets the by SQL condition.
        /// </summary>
        /// <param name="sqlCondition">The SQL condition.</param>
        /// <returns></returns>
        public async Task<List<T>> GetBySQLCondition(string sqlCondition)
        {
            using (var connection = ConnectionHelper.GetOpenConnection())
            {
                IEnumerable<T> result = await connection.GetListAsync<T>(sqlCondition);
                return result.ToList();
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetAll()
        {
            using (var connection = ConnectionHelper.GetOpenConnection())
            {
                IEnumerable<T> result = await connection.GetListAsync<T>();
                return result.ToList();
            }
        }

        /// <summary>
        /// Inserts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int?> Insert(T model)
        {
            using (var connection = ConnectionHelper.GetOpenConnection())
            {
                return await connection.InsertAsync<T>(model);
            }
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int?> Update(T model)
        {
            using (var connection = ConnectionHelper.GetOpenConnection())
            {
                return await connection.UpdateAsync<T>(model);
            }
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<int?> Delete(T model)
        {
            using (var connection = ConnectionHelper.GetOpenConnection())
            {
                return await connection.DeleteAsync<T>(model);
            }
        }

        /// <summary>
        /// Deletes the bulk.
        /// </summary>
        /// <param name="sqlCondition">The SQL condition.</param>
        /// <returns></returns>
        public async Task<int?> DeleteBulk(string sqlCondition)
        {
            using (var connection = ConnectionHelper.GetOpenConnection())
            {
                return await connection.DeleteListAsync<T>(sqlCondition);
            }
        }

        public async Task<T> ExecuteSP(string storedProcedure, object param = null)
        {
            using (var connection = ConnectionHelper.GetOpenConnection())
            {
                return (await connection.QueryAsync<T>(storedProcedure, param, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            }
        }

        public async Task<IEnumerable<T>> ExecuteGetSP(string storedProcedure, object param = null)
        {
            using (var connection = ConnectionHelper.GetOpenConnection())
            {
                return await connection.QueryAsync<T>(storedProcedure, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
