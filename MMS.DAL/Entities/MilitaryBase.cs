using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS
{
    public class MilitaryBase
    {
        public int IdBase { get; set; }
        //public int LocationId { get; set; }
        public Location location { get; set; }
        public State state { get; set; }
        public string BaseName { get; set; }
        public DateTime FoundDate { get; set; }

        public List<Garrison> Garrison { get; set; }
        public List<PersonalMilitary> personalMilitaries { get; set; }

    }
}
