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
    public class PowerSupplyController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public PowerSupplyController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var powerSupplies = _dbContext.PowerSupplies.Include(x => x.Connectors).Select(x => new PowerSupplyGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Type = x.Type,
                EfficiencyRating = x.EfficiencyRating,
                FormFactor = x.FormFactor,
                Wattage = x.Wattage,
                Connectors = x.Connectors.Select(x => new InternalConnectorGetAllResponse
                {
                    Id = x.Id,
                    Type = x.Type,
                    Quantity = x.Quantity,
                }).ToList()
            }).ToList();

            return Ok(powerSupplies);
        }

        [HttpPost]
        public ActionResult GetCompatible(PowerSupplyGetCompatibleRequest request)
        {
            var pcCase = _dbContext.Cases.Include(x => x.CompatiblePowerSupplies).FirstOrDefault(x => x.Id == request.CaseId);
            if (pcCase == null) return BadRequest("Invalid case Id");
            var compatiblePsuIds = pcCase.CompatiblePowerSupplies.Select(x => x.Id).ToList();
            var compatiblePSUs = _dbContext.PowerSupplies.Include(x => x.Connectors).Where(x => compatiblePsuIds.Contains(x.Id)).Select(x => new PowerSupplyGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Type = x.Type,
                EfficiencyRating = x.EfficiencyRating,
                FormFactor = x.FormFactor,
                Wattage = x.Wattage,
                Connectors = x.Connectors.Select(x => new InternalConnectorGetAllResponse
                {
                    Id = x.Id,
                    Type = x.Type,
                    Quantity = x.Quantity,
                }).ToList()
            }).ToList();


            return Ok(compatiblePSUs);
        }

        [HttpPost]
        public ActionResult Add(PowerSupplyAddRequest request)
        {
            var newPowerSupply = new PowerSupply
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Type = request.Type,
                EfficiencyRating = request.EfficiencyRating,
                FormFactor = request.FormFactor,
                Wattage = request.Wattage,
                CompatibleCases = new List<Case>(),
                Connectors = new List<InternalConnector>()
            };

            var compatibleCases = _dbContext.Cases.Where(x => x.FormFactor == newPowerSupply.FormFactor).ToList();
            newPowerSupply.CompatibleCases.AddRange(compatibleCases);

            foreach (var connectorId in request.InternalConnectorIds)
            {
                var connector = _dbContext.InternalConnectors.FirstOrDefault(x => x.Id == connectorId);
                if (connector == null) continue;
                newPowerSupply.Connectors.Add(connector);
            }

            _dbContext.PowerSupplies.Add(newPowerSupply);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var powerSupplyForDelete = _dbContext.PowerSupplies.FirstOrDefault(x => x.Id == id);

            if (powerSupplyForDelete == null) return BadRequest("Invalid Id");

            _dbContext.PowerSupplies.Remove(powerSupplyForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
