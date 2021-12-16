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
    public class ArmyCorpController : ControllerBase
    {
        private readonly DB_Context _context;

        public ArmyCorpController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMilitary")]
        public async Task<IActionResult> AddArmyCorp([FromBody] ArmyCorp armyCorp)
        {
            if (armyCorp.Commander == null)
                return BadRequest("Commander is null!");
            if (armyCorp.state == null)
                return BadRequest("State is null!");

            await _context.Corps.AddAsync(armyCorp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
