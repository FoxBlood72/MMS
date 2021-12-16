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
    public class LocationController : ControllerBase
    {
        private readonly DB_Context _context;

        public LocationController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddState")]
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
    }
}
