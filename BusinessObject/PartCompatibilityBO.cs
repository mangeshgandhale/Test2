using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
  public  class PartCompatibilityBO :AuditControl
    {

        public int PartLinkID { get; set; }
        public int? PartID { get; set; }
        public int ProductCategoryID { get; set; }
        public string ProductCategoryDescription { get; set; }
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public int ModelID { get; set; }
        public string ModelNo { get; set; }
        public int? ModelManufacturerId { get; set; }
        public bool Active { get; set; }
        public string UserName { get; set; }
    }
}
