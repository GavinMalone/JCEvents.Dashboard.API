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

        public IEnumerable<AssignedStock> RetrieveAssignedStockItems(string jobQuotation)
        {
            using (var connection = new SqlConnection(ConnectionString.Value))
            {
                connection.Open();

                var parameters = new { jobQuotation = jobQuotation };

                return connection.Query<AssignedStock>("dbo.RetrieveStockAssignedToJob", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void RemoveAssignedStockItems(int stockId)
        {
            using (var connection = new SqlConnection(ConnectionString.Value))
            {
                connection.Open();

                var parameters = new { stockItemId = stockId };

                connection.Execute("dbo.RemoveAssignedStockItem", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Job> GetJobs() => ExecuteListQuery<Job>("dbo.FindAllJobs");

        public void CreateJob(Job job) 
        {
            using (var connection = new SqlConnection(ConnectionString.Value))
            {
                connection.Open();
                
                var parameters = new { quotation = job.Quotation, title = job.Title, contactInformation = job.ContactInformation,
                    venue = job.Venue, eventDate = job.EventDate, eventType = (int)job.EventType };

                connection.Execute("dbo.CreateJob", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateJob(Job job)
        {
            using (var connection = new SqlConnection(ConnectionString.Value))
            {
                connection.Open();

                var parameters = new
                {
                    quotation = job.Quotation,
                    title = job.Title,
                    contactInformation = job.ContactInformation,
                    venue = job.Venue,
                    eventDate = job.EventDate,
                    eventType = (int)job.EventType,
                    what3Words = job.What3Words ?? null,
                    rooms = job.Rooms ?? null
                };

                connection.Execute("dbo.UpdateJob", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public Job FindJob(string identifier) => ExecuteQueryWithParameters<Job>("dbo.FindJob", new { quotation = identifier });

        public void DeleteJob(string jobQuotation) 
        {
            using (var connection = new SqlConnection(ConnectionString.Value))
            {
                connection.Open();

                var parameters = new { jobQuotationNumber = jobQuotation };

                connection.Execute("dbo.DeleteJob", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        private T ExecuteQueryWithParameters<T>(string storedProcedureName, object parameters)
        {
            using (var connection = new SqlConnection(ConnectionString.Value))
            {
                connection.Open();
                return connection.Query<T>(storedProcedureName, parameters ,commandType: CommandType.StoredProcedure).Single();
            }
        }

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