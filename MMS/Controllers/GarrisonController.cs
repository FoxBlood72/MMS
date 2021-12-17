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
    }
}
