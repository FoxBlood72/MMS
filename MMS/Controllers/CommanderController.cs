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
    public class CommanderController : ControllerBase
    {
        private readonly DB_Context _context;

        public CommanderController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMilitary")]
        public async Task<IActionResult> AddMilitary([FromBody] Commander commander)
        {
            if (commander.max_soldiers == 0)
                return BadRequest("Number of max soldiers is null!");

            await _context.Commanders.AddAsync(commander);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
