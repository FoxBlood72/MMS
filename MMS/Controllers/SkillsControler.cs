using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("AddState")]
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

    }
}
