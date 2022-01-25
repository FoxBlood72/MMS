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
    public class GarrisonController : ControllerBase
    {
        private readonly DB_Context _context;

        public GarrisonController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMilitary")]
        public async Task<IActionResult> AddMilitary([FromBody] Garrison garrison)
        {
            if (string.IsNullOrEmpty(garrison.name))
                return BadRequest("The name of the garrison is null!");
            if (garrison.id_garrison == 0)
                return BadRequest("The garrison id is null!");

            await _context.Garrisons.AddAsync(garrison);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("DeleteGarrisonById")]
        public async Task DeleteSkill([FromBody] int id)
        {
            Garrison loc = await GetById(id);
            _context.Garrisons.Remove(loc);
            await _context.SaveChangesAsync();
        }

        [HttpPost("GetGarrisonById")]
        public async Task<Garrison> GetById([FromBody] int id)
        {
            var st = await _context.Garrisons.FindAsync(id);
            return st;
        }

        [HttpGet("GetAllGarrisons")]

        public async Task<List<Garrison>> GetAll()
        {
            var Garrisons = await (await GetAllQuery()).ToListAsync();
            return Garrisons;

        }

        private async Task<IQueryable<Garrison>> GetAllQuery()
        {
            var query = _context.Garrisons.AsQueryable();
            return query;
        }
    }
}
