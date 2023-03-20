using Microsoft.AspNetCore.Mvc;

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


    }
}
