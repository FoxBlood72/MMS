using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        [HttpPost("DeleteStateById")]
        public async Task DeleteState([FromBody] int id)
        {
            State st = await GetById(id);
            _context.States.Remove(st);
            await _context.SaveChangesAsync();
        }

        [HttpPost("GetStateById")]
        public async Task<State> GetById([FromBody] int id)
        {
            var st = await _context.States.FindAsync(id);
            return st;
        }

        [HttpGet("GetAllStates")]

        public async Task<List<State>> GetAll()
        {
            var States = await (await GetAllQuery()).ToListAsync();
            return States;

        }

        private async Task<IQueryable<State>> GetAllQuery()
        {
            var query = _context.States.AsQueryable();
            return query;
        }
    }
}
