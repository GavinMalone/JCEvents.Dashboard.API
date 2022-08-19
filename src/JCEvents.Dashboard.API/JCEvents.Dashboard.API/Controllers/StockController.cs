using JCEvents.Dashboard.DataAccess.Domain;
using JCEvents.Dashboard.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JCEvents.Dashboard.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<StockController> _logger;

        public StockController(IRepository repository, ILogger<StockController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger;
        }

        [HttpGet(Name = "GetStockItems")]
        public IEnumerable<Stock> Get() => _repository.GetAllStockItems();

        [HttpPost()]
        public void Add(Stock item) => _repository.InsertStockItem(item);
    }
}