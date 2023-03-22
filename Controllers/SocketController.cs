using Microsoft.AspNetCore.Mvc;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Response;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SocketController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;
        public SocketController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var sockets = _dbContext.Sockets.Select(x => new SocketGetAllResponse
            {
                Id = x.Id,
                Name = x.Name
            });

            return Ok(sockets);
        }

        [HttpPost]
        public ActionResult Add(SocketAddRequest request)
        {
            var newSocket = new Socket
            {
                Name = request.Name
            };

            _dbContext.Sockets.Add(newSocket);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var socketForDelete = _dbContext.Sockets.FirstOrDefault(x => x.Id == id);

            if (socketForDelete == null) return BadRequest("Invalid Id");

            _dbContext.Sockets.Remove(socketForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
