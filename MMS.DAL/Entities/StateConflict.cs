using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS
{
    public class StateConflict
    {
        public int? state1Id { get; set; }

        [ForeignKey("state1Id")]
        public State state1 { get; set; }

        public int? state2Id { get; set; }

        [ForeignKey("state2Id")]
        public State state2 { get; set; }

        public int conflictId { get; set; }
        public Conflict conflict { get; set; }

    }
}
