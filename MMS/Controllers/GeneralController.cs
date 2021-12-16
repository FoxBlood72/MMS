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
    public class GeneralController : ControllerBase
    {
        private readonly DB_Context _context;

        public GeneralController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMilitary")]
        public async Task<IActionResult> AddMilitary([FromBody] General general)
        {
            if (general.max_div == 0)
                return BadRequest("Number of max divisions is null!");

            await _context.Generals.AddAsync(general);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
