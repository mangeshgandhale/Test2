using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class SubTypeBO
    {
       
        public Int32 SubTypeID { get; set; }
        public string SubTypeDescription { get; set; }
        public Int32 PartTypeID { get; set; }
        public bool Active { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int32  ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
