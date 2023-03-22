using Microsoft.AspNetCore.Mvc;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Response;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class InternalConnectorController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;
        public InternalConnectorController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var internalConnectors = _dbContext.InternalConnectors.Select(x => new InternalConnectorGetAllResponse
            {
                Id = x.Id,
                Type = x.Type,
                Quantity = x.Quantity
            }).ToList();

            return Ok(internalConnectors);
        }

        [HttpPost]
        public ActionResult Add(InternalConnectorAddRequest request)
        {
            var newInternalConnector = new InternalConnector
            {
                Type = request.Type,
                Quantity = request.Quantity
            };

            _dbContext.InternalConnectors.Add(newInternalConnector);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var internalConnectorForDelete = _dbContext.InternalConnectors.FirstOrDefault(x => x.Id == id);

            if (internalConnectorForDelete == null) return BadRequest("Invalid Id");

            _dbContext.InternalConnectors.Remove(internalConnectorForDelete);

            return Ok();
        }
    }
}
