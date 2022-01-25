using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DAL
{
    public interface IStateRepository
    {
        Task<List<State>> GetAll();

        Task<State> GetById(int id);
        Task Create(State state);
        Task Update(State state);

        Task Delete(State state);


    }
}
