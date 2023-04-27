using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Response;

namespace PCBuilder.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class PortController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;
        public PortController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var ports = _dbContext.Ports.Select(x => new PortGetAllResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Ok(ports);
        }
        [Authorize(Policy = "ComponentAdd")]
        [HttpPost]
        public ActionResult Add(PortAddRequest request)
        {
            var newPort = new Port
            {
                Name = request.Name
            };

            _dbContext.Ports.Add(newPort);
            _dbContext.SaveChanges();

            return Ok();
        }

        [Authorize(Policy = "ComponentDelete")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var portForDelete = _dbContext.Ports.FirstOrDefault(x => x.Id == id);

            if (portForDelete == null) return BadRequest("Invalid Id");

            _dbContext.Ports.Remove(portForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
