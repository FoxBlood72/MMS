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
    public class MilitaryBaseController : ControllerBase
    {
        private readonly DB_Context _context;

        public MilitaryBaseController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMilitaryBase")]
        public async Task<IActionResult> AddMilitaryBase([FromBody] MilitaryBase militarybase)
        {
            if (string.IsNullOrEmpty(militarybase.BaseName))
                return BadRequest("Base name is null!");
            if (militarybase.state == null)
                return BadRequest("State is null!");
            if (militarybase.location == null)
                return BadRequest("Location is null!");

            await _context.Bases.AddAsync(militarybase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        

        [HttpPost("DeleteMilitaryBaseById")]
        public async Task DeleteSkill([FromBody] int id)
        {
            MilitaryBase mb = await GetById(id);
            _context.Bases.Remove(mb);
            await _context.SaveChangesAsync();
        }

        [HttpPost("GetMilitaryBaseById")]
        public async Task<MilitaryBase> GetById([FromBody] int id)
        {
            var st = await _context.Bases.FindAsync(id);
            return st;
        }

        [HttpGet("GetAllMilitaryBase")]

        public async Task<List<MilitaryBase>> GetAll()
        {
            var MilitaryBases = await (await GetAllQuery()).ToListAsync();
            return MilitaryBases;

        }

        private async Task<IQueryable<MilitaryBase>> GetAllQuery()
        {
            var query = _context.Bases.AsQueryable();
            return query;
        }

    }
}
