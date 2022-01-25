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
    public class MilitariesSkillController : ControllerBase
    {
        private readonly DB_Context _context;

        public MilitariesSkillController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMilitarySkill")]
        public async Task<IActionResult> AddMilitaryBase([FromBody] MilitarySkill militarySkill)
        {
            await _context.MilitarySkill.AddAsync(militarySkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("GetAllMilitarySkill")]
        public async Task<List<MilitarySkill>> GetAll()
        {
            var milskills = await (await GetAllQuery()).ToListAsync();
            return milskills;

        }

        private async Task<IQueryable<MilitarySkill>> GetAllQuery()
        {
            var query = _context.MilitarySkill.AsQueryable();
            return query;
        }

    }
}
