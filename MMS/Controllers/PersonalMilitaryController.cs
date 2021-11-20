using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MMS.DAL;

namespace MMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalMilitaryController : ControllerBase
    {
        private readonly DB_Context _context;

        public PersonalMilitaryController(DB_Context context)
        {
            _context = context;
        }

        [HttpPost("AddMilitary")]
        public async Task<IActionResult> AddMilitary([FromBody] PersonalMilitary military)
        {
            if (string.IsNullOrEmpty(military.lastname))
                return BadRequest("Last name is null!");
            if (string.IsNullOrEmpty(military.firstname))
                return BadRequest("First name is null!");
            if (string.IsNullOrWhiteSpace(military.cnp))
                return BadRequest("CNP Is null!");

            await _context.Militaries.AddAsync(military);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
