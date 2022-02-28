using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ModelBO: AuditControl
    {
        public int VendorID { get; set; }
        public int ModelID { get; set; }
        public string ModelNo { get; set; }
        public bool Active { get; set; }
    }
}
