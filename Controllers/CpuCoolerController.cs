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
    public class CpuCoolerController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public CpuCoolerController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var cpuCoolers = _dbContext.CPUCoolers.Select(x => new CpuCoolerGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Type = x.Type,
                TDP = x.TDP,
                NoiseLevel = x.NoiseLevel,
                MaxRPM = x.MaxRPM,
                Sockets = GetSocketNames(x.Sockets)
            }).ToList();

            return Ok(cpuCoolers);
        }

        [HttpPost] 
        public ActionResult GetCompatible(CpuCoolerGetCompatibleRequest request)
        {
            var cpu = _dbContext.CPUs.Include(x => x.CompatibleCpuCoolers).Include(x => x.Socket).FirstOrDefault(x => x.Id == request.CpuId);
            if (cpu == null) return BadRequest("Invalid CPU Id");
            var cpuCpuCoolerIds = cpu.CompatibleCpuCoolers.Select(x => x.Id).ToList();
            var cpuCpuCoolers = _dbContext.CPUCoolers.Include(x => x.Sockets).Where(x => cpuCpuCoolerIds.Contains(x.Id)).Select(x => new CpuCoolerGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Type = x.Type,
                TDP = x.TDP,
                NoiseLevel = x.NoiseLevel,
                MaxRPM = x.MaxRPM,
                Sockets = GetSocketNames(x.Sockets)
            }).ToList();

            return Ok(cpuCpuCoolers);
        }

        [HttpPost]
        public ActionResult Add(CpuCoolerAddRequest request)
        {
            var newCpuCooler = new CPUCooler
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Type = request.Type,
                TDP = request.TDP,
                NoiseLevel = request.NoiseLevel,
                MaxRPM = request.MaxRPM,
                Sockets = new List<Socket>(),
                CompatibleCpus = new List<CPU>()
            };

            foreach (var socketId in request.SocketIds)
            {
                var socket = _dbContext.Sockets.Where(x => x.Id == socketId).FirstOrDefault();
                if (socket == null) return BadRequest("Invalid Socket Id");
                newCpuCooler.Sockets.Add(socket);
            }

            foreach (var socket in newCpuCooler.Sockets)
            {
                var compatibleCpus = _dbContext.CPUs.Where(x => x.Socket.Id == socket.Id).ToList();
                if (!compatibleCpus.Any()) continue;
                newCpuCooler.CompatibleCpus.AddRange(compatibleCpus);
            }

            _dbContext.CPUCoolers.Add(newCpuCooler);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var CPUCoolerForDelete = _dbContext.CPUCoolers.FirstOrDefault(x => x.Id == id);

            if (CPUCoolerForDelete == null) return BadRequest("Invalid Id");

            _dbContext.CPUCoolers.Remove(CPUCoolerForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }

        private static List<string> GetSocketNames(ICollection<Socket> sockets)
        {
            List<string> socketNames = new List<string>();

            foreach (var socket in sockets)
            {
                socketNames.Add(socket.Name);
            }

            return socketNames;
        }
    }
}
