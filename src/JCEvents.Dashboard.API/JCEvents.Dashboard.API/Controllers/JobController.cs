using JCEvents.Dashboard.DataAccess.Domain;
using JCEvents.Dashboard.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JCEvents.Dashboard.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<StockController> _logger;

        public JobController(IRepository repository, ILogger<StockController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        [HttpGet(Name = "GetJobs")]
        public IEnumerable<Job> Get() => _repository.GetJobs();

        [HttpPost()]
        public void Add(Job job) => _repository.InsertJob(job);
    }
}