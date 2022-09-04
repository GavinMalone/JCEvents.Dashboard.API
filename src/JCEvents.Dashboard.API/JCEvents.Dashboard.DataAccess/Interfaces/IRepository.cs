
using JCEvents.Dashboard.DataAccess.Domain;

namespace JCEvents.Dashboard.DataAccess.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Stock> GetAllStockItems();
        IEnumerable<Job> GetJobs();
        Job FindJob(string identifier);
        void CreateJob(Job job);
        void UpdateJob(Job job);
    }
}
