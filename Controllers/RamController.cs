﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using PCBuilder.Models.Request.Compatible;
using PCBuilder.Models.Response;
using System.Runtime.Intrinsics.Arm;

namespace PCBuilder.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    [ApiController]
    public class RamController : ControllerBase
    {
        private readonly PCBuilderDbContext _dbContext;

        public RamController(PCBuilderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var ram = _dbContext.Memories.Select(x => new RamGetAllResponse
            {
                Id = x.Id,
                Manufacturer = x.Manufacturer,
                Model = x.Model,
                ImageUrl = x.ImageUrl,
                Capacity = x.Capacity,
                Frequency = x.Frequency,
                Type = x.Type,
                Timing = x.Timing
            }).ToList();

            return Ok(ram);
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            var ram = _dbContext.Memories.FirstOrDefault(x => x.Id == id);

            if (ram == null)
                return NotFound();

            return Ok(ram);
        }

        [HttpPost]
        public ActionResult GetCompatible(RamGetCompatibleRequest request)
        {
            var mb = _dbContext.MotherBoards.Include(x => x.CompatibleRam).FirstOrDefault(x => x.Id == request.MotherboardId);
            var compatibleRam = new List<RamGetAllResponse>();
            if (mb != null)
            {
                compatibleRam = mb.CompatibleRam.Select(x => new RamGetAllResponse
                {
                    Id = x.Id,
                    Manufacturer = x.Manufacturer,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl,
                    Capacity = x.Capacity,
                    Frequency = x.Frequency,
                    Type = x.Type,
                    Timing = x.Timing
                }).ToList();
            } else
            {
                compatibleRam  = _dbContext.Memories.Select(x => new RamGetAllResponse
                {
                    Id = x.Id,
                    Manufacturer = x.Manufacturer,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl,
                    Capacity = x.Capacity,
                    Frequency = x.Frequency,
                    Type = x.Type,
                    Timing = x.Timing
                }).ToList();
            }

            return Ok(compatibleRam);
        }
        [Authorize(Policy = "ComponentAdd")]
        [HttpPost]
        public ActionResult Add(RamAddRequest request)
        {
            var newRam = new RAM
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                ImageUrl = request.ImageUrl,
                Capacity = request.Capacity,
                Frequency = request.Frequency,
                Type = request.Type,
                Timing = request.Timing,
                CompatibleMotherboards = new List<Motherboard>()
            };

            var compatibleMotherboards = _dbContext.MotherBoards.Where(x => x.MaxMemorySpeed >= newRam.Frequency && x.MemoryType == newRam.Type).ToList();
            newRam.CompatibleMotherboards.AddRange(compatibleMotherboards);

            _dbContext.Memories.Add(newRam);
            _dbContext.SaveChanges();

            return Ok();
        }
        [Authorize(Policy = "ComponentDelete")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var ramForDelete = _dbContext.Memories.FirstOrDefault(x => x.Id == id);

            if (ramForDelete == null) return BadRequest("Invalid Id");

            _dbContext.Memories.Remove(ramForDelete);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
