using Microsoft.AspNetCore.Mvc;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public RamController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
