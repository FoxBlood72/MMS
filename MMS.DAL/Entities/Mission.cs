using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS
{
    public class Mission
    {
        public int id_mission { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public ICollection<ArmyCorp> armyCorps { get; set; }

        public List<ArmyCorpMission> armyCorpMissions { get; set; }

    }
}
