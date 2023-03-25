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
    public class CaseController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public CaseController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var cases = _dbContext.Cases.Select(x => new CaseGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Type = x.Type,
                FormFactor = x.FormFactor,
                MaxGpuHeight = x.MaxGpuHeight,
                MaxGpuWidth = x.MaxGpuWidth
            }).ToList();

            return Ok(cases);
        }

        [HttpPost]
        public ActionResult GetCompatible(CaseGetCompatibleRequest request)
        {
            var mb = _dbContext.MotherBoards.Include(x => x.CompatibleCases).FirstOrDefault(x => x.Id == request.MotherboardId);
            if (mb == null) return BadRequest("Invalid motherboard Id");
            var mbCases = mb.CompatibleCases.Select(x => new CaseGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Type = x.Type,
                FormFactor = x.FormFactor,
                MaxGpuHeight = x.MaxGpuHeight,
                MaxGpuWidth = x.MaxGpuWidth
            }).ToList();

            var psu = _dbContext.PowerSupplies.Include(x => x.CompatibleCases).FirstOrDefault(x => x.Id == request.PowerSupplyId);
            if (psu == null) return BadRequest("Invalid power supply Id");
            var psuCases = psu.CompatibleCases.Select(x => new CaseGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Type = x.Type,
                FormFactor = x.FormFactor,
                MaxGpuHeight = x.MaxGpuHeight,
                MaxGpuWidth = x.MaxGpuWidth
            }).ToList();
            
            var gpu = _dbContext.GPUs.Include(x => x.CompatibleCases).FirstOrDefault(x => x.Id == request.GpuId);
            if (gpu == null) return BadRequest("Invalid GPU Id");
            var gpuCases = gpu.CompatibleCases.Select(x => new CaseGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Type = x.Type,
                FormFactor = x.FormFactor,
                MaxGpuHeight = x.MaxGpuHeight,
                MaxGpuWidth = x.MaxGpuWidth
            }).ToList();

            var compatibleCases = mbCases.Where(x => psuCases.Any(y => y.Id == x.Id)).Where(x => gpuCases.Any(y => y.Id == x.Id)).ToList();

            return Ok(compatibleCases);
        }

        [HttpPost]
        public ActionResult Add(CaseAddRequest request)
        {
            var newCase = new Case
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Type = request.Type,
                FormFactor = request.FormFactor,
                MaxGpuWidth = request.MaxGpuWidth,
                MaxGpuHeight = request.MaxGpuHeight,
                CompatibleMotherboards = new List<Motherboard>(),
                CompatiblePowerSupplies = new List<PowerSupply>(),
                CompatibleGpus = new List<GPU>()
            };

            var compatibleMbs = _dbContext.MotherBoards.Where(x => x.FormFactor == newCase.FormFactor).ToList();
            newCase.CompatibleMotherboards.AddRange(compatibleMbs);

            var compatiblePowerSupplies = _dbContext.PowerSupplies.Where(x => x.FormFactor == newCase.FormFactor).ToList();
            newCase.CompatiblePowerSupplies.AddRange(compatiblePowerSupplies);

            var compatibleGPUs = _dbContext.GPUs.Where(x => x.Height <= newCase.MaxGpuHeight && x.Width <= newCase.MaxGpuWidth).ToList();
            newCase.CompatibleGpus.AddRange(compatibleGPUs);

            _dbContext.Cases.Add(newCase);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var caseForDelete = _dbContext.Cases.FirstOrDefault(x => x.Id == id);

            if (caseForDelete == null) return BadRequest("Invalid Id");

            _dbContext.Cases.Remove(caseForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
