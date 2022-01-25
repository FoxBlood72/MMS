using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMS.DAL;
using MMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        private readonly DB_Context _context;

        public MissionController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMission")]
        public async Task<IActionResult> AddMission([FromBody] Mission mission)
        {
            if (string.IsNullOrEmpty(mission.name))
                return BadRequest("The mission name is null!");
            if (string.IsNullOrEmpty(mission.description))
                return BadRequest("The mission description is null!");

            await _context.Missions.AddAsync(mission);
            await _context.Missions.AddAsync(mission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("DeleteSkillById")]
        public async Task DeleteSkill([FromBody] int id)
        {
            Mission st = await GetById(id);
            _context.Missions.Remove(st);
            await _context.SaveChangesAsync();
        }

        [HttpPost("GetSkillById")]
        public async Task<Mission> GetById([FromBody] int id)
        {
            var st = await _context.Missions.FindAsync(id);
            return st;
        }

        [HttpGet("GetAllMissions")]

        public async Task<List<Mission>> GetAll()
        {
            var Missions = await (await GetAllQuery()).ToListAsync();
            return Missions;

        }

        private async Task<IQueryable<Mission>> GetAllQuery()
        {
            var query = _context.Missions.AsQueryable();
            return query;
        }

    }
}
