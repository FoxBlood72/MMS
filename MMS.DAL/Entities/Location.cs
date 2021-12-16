using System.Collections.Generic;

namespace MMS
{
    public class Location
    {
        public int id_location { get; set; }
        public string name { get; set; }
        public string province { get; set; }
        public List<MilitaryBase> bases { get; set; }
    }
}
