using Microsoft.AspNetCore.Mvc;

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


    }
}
