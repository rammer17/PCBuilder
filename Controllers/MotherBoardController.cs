using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Request.Compatible;
using PCBuilder.Models.Response;
using PCBuilder.Services;
using System.Linq;

namespace PCBuilder.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class MotherboardController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;
        private readonly IIntersectByPropertyService _intersectService;

        public MotherboardController(PCBuilderDbContext dbContext, IIntersectByPropertyService intersectService)
        {
            _dbContext = dbContext;
            _intersectService = intersectService;
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
            var compatibleCpus = new List<MotherboardGetAllResponse>();
            if (cpu != null)
            {
                compatibleCpus = cpu.CompatibleMotherboards.Select(x => new MotherboardGetAllResponse
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
            }

            var pcCase = _dbContext.Cases
                .Include(x => x.CompatibleMotherboards)
                .ThenInclude(y => y.Chipset)
                .Include(x => x.CompatibleMotherboards)
                .ThenInclude(y => y.Socket)
                .FirstOrDefault(x => x.Id == request.CaseId);
            var compatibleCases = new List<MotherboardGetAllResponse>();

            if (pcCase != null)
            {
                compatibleCases = pcCase.CompatibleMotherboards.Select(x => new MotherboardGetAllResponse
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

            }

            var ram = _dbContext.Memories
                .Include(x => x.CompatibleMotherboards)
                .ThenInclude(y => y.Chipset)
                .Include(x => x.CompatibleMotherboards)
                .ThenInclude(y => y.Socket)
                .FirstOrDefault(x => x.Id == request.RamId);
            var compatibleRam = new List<MotherboardGetAllResponse>();

            if (ram != null)
            {
                compatibleRam = ram.CompatibleMotherboards.Select(x => new MotherboardGetAllResponse
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
            }

            var compatibleMotherboards = new List<MotherboardGetAllResponse>();
            if(compatibleRam.Count <= 0 && compatibleCpus.Count <= 0 && compatibleCases.Count <= 0)
            {
                compatibleMotherboards = _dbContext.MotherBoards.Select(x => new MotherboardGetAllResponse
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
            } else
            {
                compatibleMotherboards = _intersectService.GetIntersectionByProperty<MotherboardGetAllResponse, int>(x => x.Id, compatibleCases, compatibleCpus, compatibleRam);

            }

            return Ok(compatibleMotherboards);
        }
        [Authorize(Policy = "ComponentAdd")]
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

        [Authorize(Policy = "ComponentDelete")]
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
