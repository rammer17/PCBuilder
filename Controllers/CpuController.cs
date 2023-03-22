using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Response;

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
            var cpus = _dbContext.CPUs.Include(x => x.Socket).Select(x => new CpuGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Cores = x.Cores,
                Threads = x.Threads,
                BaseClock = x.BaseClock,
                MaxBoostClock = x.MaxBoostClock,
                Socket = x.Socket.Name,
            }).ToList();

            return Ok(cpus);
        }

        [HttpPost]
        public ActionResult Add(CpuAddRequest request)
        {
            var newCpu = new CPU
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Cores = request.Cores,
                Threads = request.Threads,
                BaseClock = request.BaseClock,
                MaxBoostClock = request.MaxBoostClock,
                Socket = _dbContext.Sockets.FirstOrDefault(x => x.Id == request.SocketId)
            };

            _dbContext.CPUs.Add(newCpu);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var CpuForDelete = _dbContext.CPUs.FirstOrDefault(x => x.Id == id);

            if (CpuForDelete == null) return BadRequest("Invalid Id");

            _dbContext.CPUs.Remove(CpuForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }

    }
}
