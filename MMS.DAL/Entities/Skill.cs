using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }

        public ICollection<PersonalMilitary> militarys { get; set; }

        public List<MilitarySkill> MilitarysSkills { get; set; }

    }
}
