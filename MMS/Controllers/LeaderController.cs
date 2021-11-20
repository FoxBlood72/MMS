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
    public class LeaderController : ControllerBase
    {
        private readonly DB_Context _context;

        public LeaderController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMilitary")]
        public async Task<IActionResult> AddMilitary([FromBody] Leader leader)
        {
            if (string.IsNullOrEmpty(leader.Last_Name))
                return BadRequest("Last name is null!");
            if (string.IsNullOrEmpty(leader.First_Name))
                return BadRequest("First name is null!");

            await _context.Leaders.AddAsync(leader);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
