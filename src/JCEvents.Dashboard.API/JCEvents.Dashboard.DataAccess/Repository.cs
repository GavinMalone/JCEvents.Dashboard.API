using Dapper;
using JCEvents.Dashboard.DataAccess.Domain;
using JCEvents.Dashboard.DataAccess.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace JCEvents.Dashboard.DataAccess
{
    public class Repository : IRepository
    {
        public IEnumerable<Stock> GetAllStockItems() => ExecuteListQuery<Stock>("dbo.FindAllStock");

        public IEnumerable<Job> GetJobs() => ExecuteListQuery<Job>("dbo.FindAllJobs");

        private IList<T> ExecuteListQuery<T>(string storedProcedureName)
        {
            using (var connection = new SqlConnection(ConnectionString.Value))
            {
                connection.Open();
                return connection.Query<T>(storedProcedureName, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}