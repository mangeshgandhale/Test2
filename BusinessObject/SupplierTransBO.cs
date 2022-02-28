using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
 public   class SupplierTransBO
    {

        
            public Int32 VendorID { get; set; }
            public bool chk { get; set; }
            public Int32 PartSuppierID { get; set; }
            public Int32 PartID { get; set; }
            public string SupplierName { get; set; }
            public string VendorPartNo { get; set; }
            public string VendorPartDescription { get; set; }
            public decimal Vendorprice { get; set; }
            public decimal Ourprice { get; set; }
            public Int16 Priority { get; set; }
            public string Note { get; set; }
            public string SOURCE { get; set; }
 
    }
}
