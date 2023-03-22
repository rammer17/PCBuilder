using Microsoft.AspNetCore.Mvc;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Response;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ChipsetController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;
        public ChipsetController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var chipsets = _dbContext.Chipsets.Select(x => new ChipsetGetAllResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Ok(chipsets);
        }

        [HttpPost]
        public ActionResult Add(ChipsetAddRequest request)
        {
            var newChipset = new Chipset
            {
                Name = request.Name
            };

            _dbContext.Chipsets.Add(newChipset);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var chipsetForDelete = _dbContext.Chipsets.FirstOrDefault(x => x.Id == id);

            if (chipsetForDelete == null) return BadRequest("Invalid Id");

            _dbContext.Chipsets.Remove(chipsetForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
