using System;

namespace MMS
{
    public class Garrison
    {
        public int id_garrison { get; set; }
        public MilitaryBase MilitaryBase { get; set; }
        public int available_rooms { get; set; }
        public DateTime start_date { get; set; }
        public string name { get; set; }

    }
}
