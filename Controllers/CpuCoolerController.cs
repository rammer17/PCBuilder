using Microsoft.AspNetCore.Mvc;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CpuCoolerController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public CpuCoolerController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
