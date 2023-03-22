﻿using Microsoft.AspNetCore.Mvc;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
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
            var powerSupplies = _dbContext.PowerSupplies.Select(x => new PowerSupplyGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Type = x.Type,
                EfficiencyRating = x.EfficiencyRating,
                FormFactor = x.FormFactor,
                Wattage = x.Wattage
            }).ToList();

            return Ok(powerSupplies);
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
                Wattage = request.Wattage
            };

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
