using Microsoft.AspNetCore.Mvc;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Response;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;
        public StorageController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var storages = _dbContext.Storages.Select(x => new StorageGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                Type = x.Type,
                Capacity = x.Capacity,
                FormFactor = x.FormFactor,
                ReadSpeed = x.ReadSpeed,
                WriteSpeed = x.WriteSpeed,
                Interface = x.Interface
            }).ToList();

            return Ok(storages);
        }

        [HttpPost]
        public ActionResult Add(StorageAddRequest request)
        {
            var newStorage = new Storage
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Type = request.Type,
                Capacity = request.Capacity,
                FormFactor = request.FormFactor,
                ReadSpeed = request.ReadSpeed,
                WriteSpeed = request.WriteSpeed,
                Interface = request.Interface
            };

            _dbContext.Storages.Add(newStorage);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var storageForDelete = _dbContext.Storages.FirstOrDefault(x => x.Id == id);

            if (storageForDelete == null) return BadRequest("Invalid Id");

            _dbContext.Storages.Remove(storageForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
