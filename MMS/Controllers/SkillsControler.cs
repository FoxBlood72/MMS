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
    public class SkillsControler : ControllerBase
    {
        private readonly DB_Context _context;

        public SkillsControler(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddSkill")]
        public async Task<IActionResult> AddSkill([FromBody] Skill skill)
        {
            if (string.IsNullOrEmpty(skill.SkillName))
                return BadRequest("The skill name is null!");
            if (string.IsNullOrEmpty(skill.SkillDescription))
                return BadRequest("The description is null!");

            await _context.Skills.AddAsync(skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("DeleteSkillById")]
        public async Task DeleteSkill([FromBody] int id)
        {
            Skill st = await GetById(id);
            _context.Skills.Remove(st);
            await _context.SaveChangesAsync();
        }

        [HttpPost("GetSkillById")]
        public async Task<Skill> GetById([FromBody] int id)
        {
            var st = await _context.Skills.FindAsync(id);
            return st;
        }

        [HttpGet("GetAllSkills")]

        public async Task<List<Skill>> GetAll()
        {
            var Skills = await (await GetAllQuery()).ToListAsync();
            return Skills;

        }

        private async Task<IQueryable<Skill>> GetAllQuery()
        {
            var query = _context.Skills.AsQueryable();
            return query;
        }
    }
}
