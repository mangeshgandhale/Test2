using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
  public  class ManufacturerBO:AuditControl
    {
        public int ProductCategoryID { get; set; }
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public bool Active { get; set; }
    }
}
