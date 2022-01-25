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
    public class DivizionController : ControllerBase
    {
        private readonly DB_Context _context;

        public DivizionController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMilitary")]
        public async Task<IActionResult> AddDivizion([FromBody] Divizion divizion)
        {
            if (string.IsNullOrEmpty(divizion.DivizionName))
                return BadRequest("Divizion name is null!");
            if (string.IsNullOrEmpty(divizion.type))
                return BadRequest("Divizion type is null!");
            if (divizion.Corp == null)
                return BadRequest("ArmyCorp is null!");

            await _context.Divizions.AddAsync(divizion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("DeleteDivizionById")]
        public async Task DeleteSkill([FromBody] int id)
        {
            Divizion loc = await GetById(id);
            _context.Divizions.Remove(loc);
            await _context.SaveChangesAsync();
        }

        [HttpPost("GetDivizionById")]
        public async Task<Divizion> GetById([FromBody] int id)
        {
            var st = await _context.Divizions.FindAsync(id);
            return st;
        }

        [HttpGet("GetAllDivizions")]

        public async Task<List<Divizion>> GetAll()
        {
            var Divizions = await (await GetAllQuery()).ToListAsync();
            return Divizions;

        }

        private async Task<IQueryable<Divizion>> GetAllQuery()
        {
            var query = _context.Divizions.AsQueryable();
            return query;
        }

    }
}
