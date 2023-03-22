using Microsoft.AspNetCore.Mvc;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
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
                Sockets = new List<Socket>()
            };

            foreach (var socketId in request.SocketIds)
            {
                var socket = _dbContext.Sockets.Where(x => x.Id == socketId).FirstOrDefault();

                if (socket == null) return BadRequest("Invalid Socket Id");

                newCpuCooler.Sockets.Add(socket);
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
