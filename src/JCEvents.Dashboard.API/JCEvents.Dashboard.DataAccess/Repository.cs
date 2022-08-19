using Dapper;
using JCEvents.Dashboard.DataAccess.Domain;
using JCEvents.Dashboard.DataAccess.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace JCEvents.Dashboard.DataAccess
{
    public class Repository : IRepository
    {
        public IEnumerable<Stock> GetAllStockItems()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> GetJobs()
        {
            using (var connection = new SqlConnection(ConnectionString.Value))
            {
                connection.Open();
                return connection.Query<Job>("dbo.FindAllJobs", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public async void InsertJob(Job job)
        {

        }

        public async void InsertStockItem(Stock stock) 
        {

        }
    }
}