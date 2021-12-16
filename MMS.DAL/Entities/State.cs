
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
        public List<MilitaryBase> bases { get; set; }
        public List<ArmyCorp> corps { get; set; }
    }
}
