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
    public class StateController : ControllerBase
    {
        private readonly DB_Context _context;

        public StateController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddState")]
        public async Task<IActionResult> AddState([FromBody] State state)
        {
            if (string.IsNullOrEmpty(state.name))
                return BadRequest("The name is null!");
            if (string.IsNullOrEmpty(state.legislator))
                return BadRequest("The legislator is null!");

            await _context.States.AddAsync(state);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
