
using JCEvents.Dashboard.DataAccess.Domain;

namespace JCEvents.Dashboard.DataAccess.Interfaces
{
    public interface IRepository
    {
        void InsertStockItem(Stock stock);
        IEnumerable<Stock> GetAllStockItems();

        void InsertJob(Job job);
        IEnumerable<Job> GetJobs();
    }
}
