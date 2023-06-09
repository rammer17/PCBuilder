using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Request.Compatible;
using PCBuilder.Models.Response;

namespace PCBuilder.Controllers
{
    [Authorize]
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
                ImageUrl = x.ImageUrl,
                BaseClock = x.BaseClock,
                MaxBoostClock = x.MaxBoostClock,
                MemorySize = x.MemorySize,
                MemoryType = x.MemoryType,
                MemoryBus = x.MemoryBus,
                TDP = x.TDP,
                Height = x.Height,
                Width = x.Width
            }).ToList();

            return Ok(gpus);
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            var gpu = _dbContext.GPUs.FirstOrDefault(x => x.Id == id);

            if (gpu == null)
                return NotFound();

            return Ok(gpu);
        }

        [HttpPost] 
        public ActionResult GetCompatible(GpuGetCompatibleRequest request)
        {
            var pcCase = _dbContext.Cases.Include(x => x.CompatibleGpus).FirstOrDefault(x => x.Id == request.CaseId);
            var compatibleGpus = new List<GpuGetAllResponse>();
            if (pcCase != null)
            {
                compatibleGpus = pcCase.CompatibleGpus.Select(x => new GpuGetAllResponse
                {
                    Id = x.Id,
                    Manufacturer = x.Manufacturer,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl,
                    BaseClock = x.BaseClock,
                    MaxBoostClock = x.MaxBoostClock,
                    MemorySize = x.MemorySize,
                    MemoryType = x.MemoryType,
                    MemoryBus = x.MemoryBus,
                    TDP = x.TDP,
                    Height = x.Height,
                    Width = x.Width
                }).ToList();
            } else
            {
                compatibleGpus = _dbContext.GPUs.Select(x => new GpuGetAllResponse
                {
                    Id = x.Id,
                    Manufacturer = x.Manufacturer,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl,
                    BaseClock = x.BaseClock,
                    MaxBoostClock = x.MaxBoostClock,
                    MemorySize = x.MemorySize,
                    MemoryType = x.MemoryType,
                    MemoryBus = x.MemoryBus,
                    TDP = x.TDP,
                    Height = x.Height,
                    Width = x.Width
                }).ToList();
            }

            return Ok(compatibleGpus);
        }
        [Authorize(Policy = "ComponentAdd")]
        [HttpPost]
        public ActionResult Add(GpuAddRequest request)
        {
            var newGpu = new GPU
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                ImageUrl = request.ImageUrl,
                BaseClock = request.BaseClock,
                MaxBoostClock = request.MaxBoostClock,
                MemorySize = request.MemorySize,
                MemoryType = request.MemoryType,
                MemoryBus = request.MemoryBus,
                TDP = request.TDP,
                Width = request.Width,
                Height = request.Height,
                CompatibleCases = new List<Case>()
            };

            var compatibleCases = _dbContext.Cases.Where(x => x.MaxGpuHeight >= newGpu.Height && x.MaxGpuWidth >= newGpu.Width).ToList();
            newGpu.CompatibleCases.AddRange(compatibleCases);

            _dbContext.GPUs.Add(newGpu);
            _dbContext.SaveChanges();

            return Ok();
        }
        [Authorize(Policy = "ComponentDelete")]
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
