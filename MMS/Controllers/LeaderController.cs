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
    public class LeaderController : ControllerBase
    {
        private readonly DB_Context _context;

        public LeaderController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddLeader")]
        public async Task<IActionResult> AddMilitary([FromBody] Leader leader)
        {
            if (string.IsNullOrEmpty(leader.Last_Name))
                return BadRequest("Last name is null!");
            if (string.IsNullOrEmpty(leader.First_Name))
                return BadRequest("First name is null!");

            await _context.Leaders.AddAsync(leader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("DeleteLeaderById")]
        public async Task DeleteSkill([FromBody] int id)
        {
            Leader loc = await GetById(id);
            _context.Leaders.Remove(loc);
            await _context.SaveChangesAsync();
        }

        [HttpPost("GetLeaderById")]
        public async Task<Leader> GetById([FromBody] int id)
        {
            var st = await _context.Leaders.FindAsync(id);
            return st;
        }

        [HttpGet("GetAllLeaders")]

        public async Task<List<Leader>> GetAll()
        {
            var Leaders = await (await GetAllQuery()).ToListAsync();
            return Leaders;

        }

        private async Task<IQueryable<Leader>> GetAllQuery()
        {
            var query = _context.Leaders.AsQueryable();
            return query;
        }
    }
}
