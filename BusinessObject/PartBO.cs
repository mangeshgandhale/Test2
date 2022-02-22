using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
 public   class PartBO
    {
        public Int32 PartID { get; set; }
        public Int32 SubTypeID { get; set; }
        public Int32 ReplacementPartID { get; set; }
        
        public string PartNo { get; set; }
        public string PartDescription { get; set; }

        public string PartDetailDescription { get; set; }

        public decimal GrossWeight { get; set; }

        public Int32 Dim_L { get; set; }

        public Int32 Dim_W { get; set; }
        public Int32 Dim_H { get; set; }
        public bool Stockable { get; set; }
        public string OnlineMsg { get; set; }
        public string Note { get; set; }

        public Int32 StatusId { get; set; }
        public bool Returnable { get; set; }
        public bool Publish { get; set; }

        public Int32 CreatedBy { get; set; }

        public List<CompatibilityTrans> CompatibilityTrans { get; set; }


    }
    public class CompatibilityTrans

    {
        public Int32 chk { get; set; }
        public Int32 PartLinkID { get; set; }
        public Int32 PartID { get; set; }
        public string VendorName { get; set; }
        public string ModelNo { get; set; }
        public Int32 ModelManufacturerId { get; set; }
        public bool Active { get; set; }
        public string FirstName { get; set; }
        public Int32 ModelID { get; set; }
        public Int32 VendorID { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProductCategoryDescription { get; set; }
        
    }
}
