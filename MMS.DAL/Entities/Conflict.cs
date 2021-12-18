using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS
{
    public class Conflict
    {
        public int id_conflict { get; set; }
        public string name { get; set; }
        public DateTime start_date { get; set; }
        public string description { get; set; }
        public List<StateConflict> stateConflicts { get; set; }

        public ICollection<State> states1;

        public ICollection<State> states2;
    }
}
