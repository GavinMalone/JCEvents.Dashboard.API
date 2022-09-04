using JCEvents.Dashboard.DataAccess.Domain;
using JCEvents.Dashboard.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JCEvents.Dashboard.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ManageJobController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<StockController> _logger;

        public ManageJobController(IRepository repository, ILogger<StockController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        [HttpGet(Name = "FindJob")]
        public Job Find(string identifier) => _repository.FindJob(identifier);

        [HttpPost(Name = "UpdateJob")]
        public void Update(Job job) => _repository.UpdateJob(job);
         
    }
}
