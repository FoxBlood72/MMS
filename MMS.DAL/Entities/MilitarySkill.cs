using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS
{
    public class MilitarySkill
    {
        public PersonalMilitary military { get; set; }
        public int militaryId { get; set; }

        public Skill skill { get; set; }
        public int skillId { get; set; }

        public float militaryGrade { get; set; }

    }
}
