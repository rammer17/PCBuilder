using Microsoft.AspNetCore.Mvc;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Response;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GpuController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public GpuController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var gpus = _dbContext.GPUs.Select(x => new GpuGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                BaseClock = x.BaseClock,
                MaxBoostClock = x.MaxBoostClock,
                MemorySize = x.MemorySize,
                MemoryType = x.MemoryType,
                MemoryBus = x.MemoryBus,
                TDP = x.TDP
            }).ToList();

            return Ok(gpus);
        }

        [HttpPost]
        public ActionResult Add(GpuAddRequest request)
        {
            var newGpu = new GPU
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                BaseClock = request.BaseClock,
                MaxBoostClock = request.MaxBoostClock,
                MemorySize = request.MemorySize,
                MemoryType = request.MemoryType,
                MemoryBus = request.MemoryBus,
                TDP = request.TDP
            };

            _dbContext.GPUs.Add(newGpu);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var GPUForDelete = _dbContext.GPUs.FirstOrDefault(x => x.Id == id);

            if (GPUForDelete == null) return BadRequest("Invalid Id");

            _dbContext.GPUs.Remove(GPUForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
