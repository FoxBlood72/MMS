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
    public class MilitaryBaseController : ControllerBase
    {
        private readonly DB_Context _context;

        public MilitaryBaseController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMilitary")]
        public async Task<IActionResult> AddMilitaryBase([FromBody] MilitaryBase militarybase)
        {
            if (string.IsNullOrEmpty(militarybase.BaseName))
                return BadRequest("Base name is null!");
            if (militarybase.state == null)
                return BadRequest("State is null!");
            if (militarybase.location == null)
                return BadRequest("Location is null!");

            await _context.Bases.AddAsync(militarybase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
