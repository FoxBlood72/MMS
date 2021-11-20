using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DAL.Entities
{
    public class Leader
    {
        public int Id { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public char sex { get; set; }

        public DateTime birth_date { get; set; }
    }
}
