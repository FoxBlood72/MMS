using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMS.DAL;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalMilitaryController : ControllerBase
    {
        private readonly DB_Context _context;

        public PersonalMilitaryController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMilitary")]
        public async Task<IActionResult> AddMilitary([FromBody] PersonalMilitary military)
        {
            if (string.IsNullOrEmpty(military.lastname))
                return BadRequest("Last name is null!");
            if (string.IsNullOrEmpty(military.firstname))
                return BadRequest("First name is null!");
            if (string.IsNullOrWhiteSpace(military.cnp))
                return BadRequest("CNP Is null!");

            await _context.Militaries.AddAsync(military);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPost("DeletePersonalMilitaryById")]
        public async Task DeletePersonalMilitary([FromBody] int id)
        {
            PersonalMilitary st = await GetById(id);
            _context.Militaries.Remove(st);
            await _context.SaveChangesAsync();
        }

        [HttpPost("GetPersonalMilitaryById")]
        public async Task<PersonalMilitary> GetById([FromBody] int id)
        {
            var st = await _context.Militaries.FindAsync(id);
            return st;
        }

        [HttpGet("GetAllPersonalMilitarys")]

        public async Task<List<PersonalMilitary>> GetAll()
        {
            var PersonalMilitarys = await (await GetAllQuery()).ToListAsync();
            return PersonalMilitarys;

        }


        [HttpGet("Get-Best")]
        public async Task<IActionResult> getBestMilitaries()
        {
            var military_top = this._context.MilitarySkill.GroupBy(x => x.militaryId).Select(x => new
            {
                militaryId = x.Key,
                count_mil = x.Count(),
                sum_skill = x.Sum(y => y.militaryGrade)
            }).Join(this._context.Militaries, x => x.militaryId, y => y.ID_PERS, (x, y) => new
            {
                y.firstname,
                y.lastname,
                x.sum_skill,
                x.count_mil
            }).OrderByDescending(x => x.count_mil).OrderByDescending(x => x.sum_skill);

            return Ok(military_top);
        }

        [HttpPost("Get-Best-By-Skill")]
        public async Task<IActionResult> getBestMilitaries([FromBody] int idSkill)
        {
            var military_top = this._context.MilitarySkill.Join(this._context.Militaries, x => x.militaryId, y => y.ID_PERS, (x, y) => new {
                y.firstname,
                y.lastname,
                x.militaryGrade,
                x.skillId
            }).Join(this._context.Skills, x => x.skillId, y => y.SkillId, (x, y) => new { 
                x.firstname,
                x.lastname,
                x.militaryGrade,
                x.skillId,
                y.SkillName
            }).Where(x => x.skillId == idSkill).OrderByDescending(x => x.militaryGrade);

            return Ok(military_top);
        }

        [HttpGet("Get-Military-Grades")]
        public async Task<IActionResult> getMilitariesGrades()
        {
            var militaries_grades = this._context.Militaries.Join(this._context.MilitarySkill, x => x.ID_PERS, y => y.militaryId, (x, y) => new
            {
                x.cnp,
                x.firstname,
                x.lastname,
                y.skillId,
                y.militaryGrade
            }).Join(this._context.Skills, x => x.skillId, y => y.SkillId, (x, y) => new { 
                x.cnp,
                x.firstname,
                x.lastname,
                x.skillId,
                x.militaryGrade,
                y.SkillName
            }).OrderByDescending(x => x.cnp).OrderByDescending(x => x.SkillName).OrderByDescending(x => x.militaryGrade);

            return Ok(militaries_grades);
        }



        private async Task<IQueryable<PersonalMilitary>> GetAllQuery()
        {
            var query = _context.Militaries.AsQueryable();
            return query;
        }

        


    }
}
