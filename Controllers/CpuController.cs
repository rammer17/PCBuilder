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
                compatibleCpus = GetIntersectionByProperty<CpuGetAllResponse, int>(x => x.Id, cpuCoolerCpus, mbCpus);
            }

            return Ok(compatibleCpus);
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
                Socket = _dbContext.Sockets.FirstOrDefault(x => x.Id == request.SocketId),
                CompatibleMotherboards = new List<Motherboard>()
            };

            var compatibleMbs = _dbContext.MotherBoards.Where(x => x.SocketId == request.SocketId).ToList();
            newCpu.CompatibleMotherboards.AddRange(compatibleMbs);

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

        static List<T> GetIntersectionByProperty<T, TKey>(Func<T, TKey> keySelector, params List<T>[] lists)
        {
            if (lists == null || lists.Length == 0)
            {
                return new List<T>();
            }

            Dictionary<TKey, int> keyCounts = new Dictionary<TKey, int>();
            foreach (List<T> list in lists.Where(l => l.Any()))
            {
                foreach (T item in list)
                {
                    TKey key = keySelector(item);
                    if (keyCounts.ContainsKey(key))
                    {
                        keyCounts[key]++;
                    }
                    else
                    {
                        keyCounts.Add(key, 1);
                    }
                }
            }

            List<TKey> keys = keyCounts.Where(kvp => kvp.Value == lists.Count(l => l.Any())).Select(kvp => kvp.Key).ToList();

            Dictionary<TKey, T> objectMap = new Dictionary<TKey, T>();
            foreach (List<T> list in lists)
            {
                foreach (T item in list)
                {
                    TKey key = keySelector(item);
                    if (keys.Contains(key) && !objectMap.ContainsKey(key))
                    {
                        objectMap.Add(key, item);
                    }
                }
            }
            List<T> result = objectMap.Values.ToList();

            return result;
        }

    }
}
