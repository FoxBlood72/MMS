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
    public class ConflictController : ControllerBase
    {
        private readonly DB_Context _context;

        public ConflictController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddConflict")]
        public async Task<IActionResult> AddConflict([FromBody] Conflict conflict)
        {
            if (string.IsNullOrEmpty(conflict.name))
                return BadRequest("The name of the conflict is null!");
            if (string.IsNullOrEmpty(conflict.description))
                return BadRequest("The description is null!");

            await _context.Conflicts.AddAsync(conflict);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost("DeleteConflictById")]
        public async Task DeleteSkill([FromBody] int id)
        {
            Conflict loc = await GetById(id);
            _context.Conflicts.Remove(loc);
            await _context.SaveChangesAsync();
        }

        [HttpPost("GetConflictById")]
        public async Task<Conflict> GetById([FromBody] int id)
        {
            var st = await _context.Conflicts.FindAsync(id);
            return st;
        }

        [HttpGet("GetAllConflicts")]

        public async Task<List<Conflict>> GetAll()
        {
            var Conflicts = await (await GetAllQuery()).ToListAsync();
            return Conflicts;

        }

        private async Task<IQueryable<Conflict>> GetAllQuery()
        {
            var query = _context.Conflicts.AsQueryable();
            return query;
        }
    }
}
