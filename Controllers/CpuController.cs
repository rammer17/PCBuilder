using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Response;
using PCBuilder.Services;

namespace PCBuilder.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class CpuController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;
        private readonly IIntersectByPropertyService _intersectService;

        public CpuController(PCBuilderDbContext dbContext, IIntersectByPropertyService intersectService)
        {
            _dbContext = dbContext;
            _intersectService = intersectService;
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
                Socket = x.Socket.Name
            }).ToList();

            return Ok(cpus);
        }

        [HttpPost]
        public ActionResult GetCompatible(CpuGetCompatibleRequest request)
        {

            var mb = _dbContext.MotherBoards.Include(x => x.CompatibleCpus).FirstOrDefault(x => x.Id == request.MotherboardId);
            var mbCpus = new List<CpuGetAllResponse>();
            if (mb != null)
            {
                var mbCpuIds = mb.CompatibleCpus.Select(x => x.Id).ToList();
                mbCpus = _dbContext.CPUs.Include(x => x.Socket).Where(x => mbCpuIds.Contains(x.Id)).Select(x => new CpuGetAllResponse
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
            }

            var cpuCooler = _dbContext.CPUCoolers.Include(x => x.CompatibleCpus).FirstOrDefault(x => x.Id == request.CpuCoolerId);
            var cpuCoolerCpus = new List<CpuGetAllResponse>();

            if (cpuCooler != null)
            {
                var cpuCoolerCpuIds = cpuCooler.CompatibleCpus.Select(x => x.Id).ToList();
                cpuCoolerCpus = _dbContext.CPUs.Include(x => x.Socket).Where(x => cpuCoolerCpuIds.Contains(x.Id)).Select(x => new CpuGetAllResponse
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
            }

            var compatibleCpus = new List<CpuGetAllResponse>();
            if (cpuCoolerCpus.Count <= 0 && mbCpus.Count <= 0)
            {
                compatibleCpus = _dbContext.CPUs.Select(x => new CpuGetAllResponse
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
            }
            else
            {
                compatibleCpus = _intersectService.GetIntersectionByProperty<CpuGetAllResponse, int>(x => x.Id, cpuCoolerCpus, mbCpus);
            }

            return Ok(compatibleCpus);
        }
        [Authorize(Policy = "ComponentAdd")]
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
                Socket = _dbContext.Sockets.FirstOrDefault(x => x.Id == request.SocketId),
                CompatibleMotherboards = new List<Motherboard>()
            };

            var compatibleMbs = _dbContext.MotherBoards.Where(x => x.SocketId == request.SocketId).ToList();
            newCpu.CompatibleMotherboards.AddRange(compatibleMbs);

            _dbContext.CPUs.Add(newCpu);
            _dbContext.SaveChanges();

            return Ok();
        }
        [Authorize(Policy = "ComponentDelete")]
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
