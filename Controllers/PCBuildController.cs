using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Response;
using System.Security.Claims;

namespace PCBuilder.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class PCBuildController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public PCBuildController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAllByUser()
        {
            var id = GetUserId();

            var pcBuilds = _dbContext.Builds.Where(x => x.UserId == id).Select(x => new PCBuildGetAllResponse
            {
                Id = x.Id,
                CpuId = x.CpuId,
                CpuCoolerId = x.CpuId,
                MotherboardId = x.MotherboardId,
                RamId = x.RamId,
                StorageId = x.StorageId,
                GpuId = x.GpuId,
                CaseId = x.CaseId,
                PowerSupplyId = x.PowerSupplyId
            });

            return Ok(pcBuilds);
        }

        [HttpPost]
        public ActionResult Create(PCBuildAddRequest request)
        {
            var pcBuild = new PCBuild
            {
                CpuId = request.CpuId,
                CpuCoolerId = request.CpuCoolerId,
                MotherboardId = request.MotherboardId,
                RamId = request.RamId,
                StorageId = request.StorageId,
                GpuId = request.GpuId,
                CaseId = request.CaseId,
                PowerSupplyId = request.PowerSupplyId
            };

            _dbContext.Builds.Add(pcBuild);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var userId = GetUserId();
            var pcBuildForDelete = _dbContext.Builds.FirstOrDefault(x => x.Id == id);

            if(pcBuildForDelete != null)
                return BadRequest("Cannot find pc build with the given id");

            if (pcBuildForDelete?.UserId != userId)
                return BadRequest("You cannot delete someone else's pc configuration");

            _dbContext.Builds.Remove(pcBuildForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }

        private int GetUserId()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = int.Parse(claimsIdentity?.FindFirst(ClaimTypes.Name)?.Value!);
            return userId;
        }
    }
}
