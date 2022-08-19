
using JCEvents.Dashboard.DataAccess.Domain;

namespace JCEvents.Dashboard.DataAccess.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Stock> GetAllStockItems();
        IEnumerable<Job> GetJobs();
    }
}
