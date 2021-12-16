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
    public class ConflictController : ControllerBase
    {
        private readonly DB_Context _context;

        public ConflictController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMilitary")]
        public async Task<IActionResult> AddMilitary([FromBody] Conflict conflict)
        {
            if (string.IsNullOrEmpty(conflict.name))
                return BadRequest("The name of the conflict is null!");
            if (string.IsNullOrEmpty(conflict.description))
                return BadRequest("The description is null!");

            await _context.Conflicts.AddAsync(conflict);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
