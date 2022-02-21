using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
 public   class PartTypeBO
    {
        public Int32 PartTypeID { get; set; }

        public string PartTypeDescription { get; set; }

        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
        //public Int32 ModifiedBy { get; set; }
        //public DateTime ModifiedDate { get; set; }


        public List<PartTypeBO> DDLPartTypes { get; set; }
        public List<PartTypeBO> PartTypeGridData { get; set; }


        //    public virtual List<PartTypeBO> _PartTypeBO { get; set; }

    }
}
