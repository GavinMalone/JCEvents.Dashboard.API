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