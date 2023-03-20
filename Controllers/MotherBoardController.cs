using Microsoft.AspNetCore.Mvc;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MotherboardController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public MotherboardController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
