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
    public class ArmyCorpController : ControllerBase
    {
        private readonly DB_Context _context;

        public ArmyCorpController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddArmyCorp")]
        public async Task<IActionResult> AddArmyCorp([FromBody] ArmyCorp armyCorp)
        {
            if (armyCorp.Commander == null)
                return BadRequest("Commander is null!");
            if (armyCorp.state == null)
                return BadRequest("State is null!");

            await _context.Corps.AddAsync(armyCorp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("DeleteArmyCorpById")]
        public async Task DeleteSkill([FromBody] int id)
        {
            ArmyCorp loc = await GetById(id);
            _context.Corps.Remove(loc);
            await _context.SaveChangesAsync();
        }

        [HttpPost("GetArmyCorpById")]
        public async Task<ArmyCorp> GetById([FromBody] int id)
        {
            var st = await _context.Corps.FindAsync(id);
            return st;
        }

        [HttpGet("GetAllArmyCorps")]

        public async Task<List<ArmyCorp>> GetAll()
        {
            var ArmyCorps = await (await GetAllQuery()).ToListAsync();
            return ArmyCorps;

        }

        private async Task<IQueryable<ArmyCorp>> GetAllQuery()
        {
            var query = _context.Corps.AsQueryable();
            return query;
        }

    }
}
