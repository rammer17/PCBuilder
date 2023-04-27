using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Response;

namespace PCBuilder.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class StorageSlotController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public StorageSlotController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var storageSlots = _dbContext.StorageSlots.Select(x => new StorageSlotGetAllResponse
            {
                Id = x.Id,
                Type = x.Type
            }).ToList();

            return Ok(storageSlots);
        }

        [Authorize(Policy = "ComponentAdd")]
        [HttpPost]
        public ActionResult Add(StorageSlotAddRequest request)
        {
            var newStorageSlot = new StorageSlot
            {
                Type = request.Type
            };

            _dbContext.StorageSlots.Add(newStorageSlot);
            _dbContext.SaveChanges();

            return Ok();
        }
        [Authorize(Policy = "ComponentDelete")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var storageSlotForDelete = _dbContext.StorageSlots.FirstOrDefault(x => x.Id == id);

            if (storageSlotForDelete == null) return BadRequest("Invalid Id");

            _dbContext.StorageSlots.Remove(storageSlotForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
