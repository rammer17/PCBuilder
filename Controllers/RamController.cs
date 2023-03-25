using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Request.Compatible;
using PCBuilder.Models.Response;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public RamController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var ram = _dbContext.Memories.Select(x => new RamGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Capacity = x.Capacity,
                Frequency = x.Frequency,
                Type = x.Type,
                Timing = x.Timing
            }).ToList();

            return Ok(ram);
        }

        [HttpPost]
        public ActionResult GetCompatible(RamGetCompatibleRequest request)
        {
            var mb = _dbContext.MotherBoards.Include(x => x.CompatibleRam).FirstOrDefault(x => x.Id == request.MotherboardId);
            if (mb == null) return BadRequest("Invalid motherboard Id");
            var compatibleRam = mb.CompatibleRam.Select(x => new RamGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Capacity = x.Capacity,
                Frequency = x.Frequency,
                Type = x.Type,
                Timing = x.Timing
            }).ToList();


            return Ok(compatibleRam);
        }

        [HttpPost]
        public ActionResult Add(RamAddRequest request)
        {
            var newRam = new RAM
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Capacity = request.Capacity,
                Frequency = request.Frequency,
                Type = request.Type,
                Timing = request.Timing,
                CompatibleMotherboards = new List<Motherboard>()
            };

            var compatibleMotherboards = _dbContext.MotherBoards.Where(x => x.MaxMemorySpeed >= newRam.Frequency && x.MemoryType == newRam.Type).ToList();
            newRam.CompatibleMotherboards.AddRange(compatibleMotherboards);

            _dbContext.Memories.Add(newRam);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var ramForDelete = _dbContext.Memories.FirstOrDefault(x => x.Id == id);

            if (ramForDelete == null) return BadRequest("Invalid Id");

            _dbContext.Memories.Remove(ramForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
