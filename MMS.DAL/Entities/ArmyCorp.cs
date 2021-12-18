using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using MMS.DAL.Entities;

namespace MMS
{
    public class ArmyCorp
    {
        public int CorpId { get; set; }

        [ForeignKey("PersonalMilitary")]
        public int? CommanderId { get; set; }

        public PersonalMilitary Commander { get; set; }

        public int victories;

        public int defeates;
        public State state { get; set; }
        public List<Divizion> divizions { get; set; }
    }
}
