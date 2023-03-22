using Microsoft.AspNetCore.Mvc;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
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
                MotherboardFormFactor = x.MotherboardFormFactor
            }).ToList();

            return Ok(cases);
        }

        [HttpPost]
        public ActionResult Add(CaseAddRequest request)
        {
            var newCase = new Case
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Type = request.Type,
                MotherboardFormFactor = request.MotherboardFormFactor
            };

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
