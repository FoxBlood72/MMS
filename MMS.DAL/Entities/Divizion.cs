using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DAL.Entities
{
    public class Divizion
    {
        public int DivizionID { get; set; }
        public string DivizionName { get; set;}
        public int GeneralID { get; set; }
        public string type { get; set; }
        public DateTime FoundDate { get; set; }

        public ArmyCorp Corp { get; set; }

        public List<PersonalMilitary> personalMilitaries { get; set; }
    }
}
