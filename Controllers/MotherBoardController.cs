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
    public class MotherboardController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public MotherboardController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var motherboards = _dbContext.MotherBoards.Include(x => x.Socket).Include(x => x.Chipset).Select(x => new MotherboardGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                FormFactor = x.FormFactor,
                Socket = x.Socket.Name,
                Chipset = x.Chipset.Name,
                MemorySlots = x.MemorySlots,
                MemoryType = x.MemoryType,
                MaxMemorySpeed = x.MaxMemorySpeed,
                Wifi = x.Wifi,
                
            }).ToList();

            return Ok(motherboards);
        }

        [HttpPost]
        public ActionResult GetCompatible(MotherboardGetCompatibleRequest request)
        {
            var cpu = _dbContext.CPUs
                .Include(x => x.CompatibleMotherboards)
                .ThenInclude(y => y.Chipset)
                .Include(x => x.CompatibleMotherboards)
                .ThenInclude(y => y.Socket)
                .FirstOrDefault(x => x.Id == request.CpuId);
            if (cpu == null) return BadRequest("Invalid CPU Id");
            var compatibleCpus = cpu.CompatibleMotherboards.Select(x => new MotherboardGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                FormFactor = x.FormFactor,
                Socket = x.Socket.Name,
                Chipset = x.Chipset.Name,
                MemorySlots = x.MemorySlots,
                MemoryType = x.MemoryType,
                MaxMemorySpeed = x.MaxMemorySpeed,
                Wifi = x.Wifi
            }).ToList();

            var pcCase = _dbContext.Cases
                .Include(x => x.CompatibleMotherboards)
                .ThenInclude(y => y.Chipset)
                .Include(x => x.CompatibleMotherboards)
                .ThenInclude(y => y.Socket)
                .FirstOrDefault(x => x.Id == request.CaseId);
            if (pcCase == null) return BadRequest("Invalid case Id");
            var compatibleCases = pcCase.CompatibleMotherboards.Select(x => new MotherboardGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                FormFactor = x.FormFactor,
                Socket = x.Socket.Name,
                Chipset = x.Chipset.Name,
                MemorySlots = x.MemorySlots,
                MemoryType = x.MemoryType,
                MaxMemorySpeed = x.MaxMemorySpeed,
                Wifi = x.Wifi
            }).ToList();

            var ram = _dbContext.Memories
                .Include(x => x.CompatibleMotherboards)
                .ThenInclude(y => y.Chipset)
                .Include(x => x.CompatibleMotherboards)
                .ThenInclude(y => y.Socket)
                .FirstOrDefault(x => x.Id == request.RamId);
            if (ram == null) return BadRequest("Invalid ram Id");
            var compatibleRam = ram.CompatibleMotherboards.Select(x => new MotherboardGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                FormFactor = x.FormFactor,
                Socket = x.Socket.Name,
                Chipset = x.Chipset.Name,
                MemorySlots = x.MemorySlots,
                MemoryType = x.MemoryType,
                MaxMemorySpeed = x.MaxMemorySpeed,
                Wifi = x.Wifi
            }).ToList();

            var compatibleMotherboards = compatibleCpus.Where(x => compatibleCases.Any(y => y.Id == x.Id)).Where(x => compatibleRam.Any(y => y.Id == x.Id)).ToList();


            return Ok(compatibleMotherboards);
        }

        [HttpPost]
        public ActionResult Add(MotherboardAddRequest request)
        {
            var newMb = new Motherboard
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                FormFactor = request.FormFactor,
                Socket = _dbContext.Sockets.FirstOrDefault(x => x.Id == request.SocketId),
                Chipset = _dbContext.Chipsets.FirstOrDefault(x => x.Id == request.ChipsetId),
                MemorySlots = request.MemorySlots,
                MemoryType= request.MemoryType,
                MaxMemorySpeed= request.MaxMemorySpeed,
                Wifi = request.Wifi,
                BackPanelPorts = new List<Port>(),
                InternalConnectors = new List<InternalConnector>(),
                StorageSlots = new List<StorageSlot>(),
                CompatibleCpus = new List<CPU>(),
                CompatibleCases = new List<Case>(),
                CompatibleRam = new List<RAM>()
            };

            if(newMb.Socket == null)
            {
                return BadRequest("Invalid socket id");
            }
            if(newMb.Chipset == null)
            {
                return BadRequest("Invalid chipset id");
            }

            var compatibleCpus = _dbContext.CPUs.Where(x => x.Socket.Id == newMb.Socket.Id).ToList();
            newMb.CompatibleCpus.AddRange(compatibleCpus);

            var compatibleCases = _dbContext.Cases.Where(x => x.FormFactor == newMb.FormFactor).ToList();
            newMb.CompatibleCases.AddRange(compatibleCases);

            var compatibleRam = _dbContext.Memories.Where(x => x.Frequency <= newMb.MaxMemorySpeed && x.Type == newMb.MemoryType).ToList();
            newMb.CompatibleRam.AddRange(compatibleRam);

            foreach (var portId in request.PortIds)
            {
                var port = _dbContext.Ports.FirstOrDefault(x => x.Id == portId);
                if (port == null) return BadRequest("Invalid port id");
                newMb.BackPanelPorts.Add(port);
            }
            foreach (var connectorId in request.ConnectorIds)
            {
                var connector = _dbContext.InternalConnectors.FirstOrDefault(x => x.Id == connectorId);
                if (connector == null) return BadRequest("Invalid connector id");
                newMb.InternalConnectors.Add(connector);
            }
            foreach (var storageSlotId in request.StorageSlotIds)
            {
                var storageSlot = _dbContext.StorageSlots.FirstOrDefault(x => x.Id == storageSlotId);
                if (storageSlot == null) return BadRequest("Invalid storage slot id");
                newMb.StorageSlots.Add(storageSlot);
            }


            _dbContext.MotherBoards.Add(newMb);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var motherboardForDelete = _dbContext.MotherBoards.FirstOrDefault(x => x.Id == id);

            if (motherboardForDelete == null) return BadRequest("Invalid Id");

            _dbContext.MotherBoards.Remove(motherboardForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
