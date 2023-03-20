using Microsoft.AspNetCore.Mvc;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StorageSlotController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public StorageSlotController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
