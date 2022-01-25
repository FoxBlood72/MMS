using MMS.DAL.Entities;
using System;
using System.Collections.Generic;

namespace MMS
{
    public class PersonalMilitary
    {
        public int ID_PERS { get; set; }
        public Divizion divizion { get; set; }
        public MilitaryBase? mBase { get; set; }
        public float salary { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string cnp { get; set; }
        public string sex { get; set; }
        public DateTime hire_date { get; set; }
        //public List<PersonalMilitary> Commanders { get; set; }

        public ICollection<Skill> skills { get; set; }

        public List<MilitarySkill> MilitarysSkills { get; set; }
    }
}
