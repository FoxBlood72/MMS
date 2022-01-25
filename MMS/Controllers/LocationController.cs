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
    public class LocationController : ControllerBase
    {
        private readonly DB_Context _context;

        public LocationController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddLocation([FromBody] Location location)
        {
            if (string.IsNullOrEmpty(location.name))
                return BadRequest("The name is null!");
            if (string.IsNullOrEmpty(location.province))
                return BadRequest("The location is null!");

            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("DeleteLocationById")]
        public async Task DeleteSkill([FromBody] int id)
        {
            Location loc = await GetById(id);
            _context.Locations.Remove(loc);
            await _context.SaveChangesAsync();
        }

        [HttpPost("GetLocationById")]
        public async Task<Location> GetById([FromBody] int id)
        {
            var st = await _context.Locations.FindAsync(id);
            return st;
        }

        [HttpGet("GetAllLocations")]

        public async Task<List<Location>> GetAll()
        {
            var locations = await (await GetAllQuery()).ToListAsync();
            return locations;

        }

        private async Task<IQueryable<Location>> GetAllQuery()
        {
            var query = _context.Locations.AsQueryable();
            return query;
        }

    }
}
