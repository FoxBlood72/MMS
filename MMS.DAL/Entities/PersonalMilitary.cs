using System;
using System.Collections.Generic;

namespace MMS
{
    public class PersonalMilitary
    {
        public int ID_PERS { get; set; }
        public int ID_DIVIZION { get; set; }
        public int ID_BASE { get; set; }
        public float salary { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string cnp { get; set; }
        public char sex { get; set; }
        public DateTime hire_date { get; set; }
        //public List<PersonalMilitary> Commanders { get; set; }
    }
}
