using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{

    public abstract class AuditControl
    {
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public System.Nullable<Int32> ModifiedBy { get; set; }
        public System.Nullable<DateTime> ModifiedDate { get; set; }
    }
}
