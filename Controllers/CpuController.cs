using Microsoft.AspNetCore.Mvc;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CpuController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public CpuController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Add(CpuAddRequest request)
        {
            var newCpu = new CPU {
                Make = request.Make,
                Model = request.Model,
                Cores = request.Cores,
                Threads = request.Threads,
                BaseClock = request.BaseClock,
                MaxBoostClock = request.MaxBoostClock,
                /*Socket = request.Socket*/
            };


            return Ok(newCpu);
        }

    }
}
