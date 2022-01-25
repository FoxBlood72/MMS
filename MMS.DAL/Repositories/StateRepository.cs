using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DAL
{
    public class StateRepository : IStateRepository
    {
        private readonly DB_Context _context;

        public StateRepository(DB_Context context)
        {
            _context = context;
        }

        public async Task Create(State state)
        {
            await _context.States.AddAsync(state);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(State state)
        {
            _context.States.Remove(state);
            await _context.SaveChangesAsync();
        }

        public async Task<List<State>> GetAll()
        {
            var States = await (await GetAllQuery()).ToListAsync();
            return States;
        }

        public async Task<State> GetById(int id)
        {
            var st = await _context.States.FindAsync(id);
            return st;
        }

        public async Task Update(State state)
        {
            _context.States.Update(state);
            await _context.SaveChangesAsync();
        }

        private async Task<IQueryable<State>> GetAllQuery()
        {
            var query = _context.States.AsQueryable();
            return query;
        }
    }
}
