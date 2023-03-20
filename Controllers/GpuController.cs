using Microsoft.AspNetCore.Mvc;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GpuController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public GpuController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
