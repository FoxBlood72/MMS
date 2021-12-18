
using System.Collections.Generic;

namespace MMS
{
    public class State
    {
        public int ID_STATE { get; set; }
        public string name { get; set; }
        public int population { get; set; }
        public int surface { get; set; }
        public string legislator { get; set; }
        public int id_leader { get; set; }
        public virtual ICollection<MilitaryBase> bases { get; set; }
        public virtual ICollection<ArmyCorp> corps { get; set; }
        public List<StateConflict> state1Conflicts { get; set; }
        public List<StateConflict> state2Conflicts { get; set; }
        public ICollection<Conflict> conflicts { get; set; }
    }
}
