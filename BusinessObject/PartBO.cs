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

        public Int32 chkdel { get; set; }
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
    public class RelatedPartTrans

    {
        public Int32 PartID { get; set; }
        public string PartNo { get; set; }
        public string PartDescription { get; set; }
        public string PartTypeDescription { get; set; }
        public string SubTypeDescription { get; set; }

            
    }

    public class SupplierTrans

    {
        public Int32 VendorID { get; set; }
        public bool chk { get; set; }
        public Int32 PartSuppierID { get; set; }
        public Int32 PartID { get; set; }
        public string SuppierName { get; set; }
        public string VendorPartNo { get; set; }
        public string VendorPartDescription { get; set; }
        public decimal Vendorprice { get; set; }
        public decimal Ourprice { get; set; }
        public Int16 Priority { get; set; }
        public string Note { get; set; }
        public string SOURCE { get; set; }
   
    }
    public class ConditionPriceTrans

    {


                                 

        public Int32 chk { get; set; }
        public string ConditionDescription { get; set; }
        public Int32 PartConditionPriceID { get; set; }
        public Int32 ConditionID { get; set; }
        public Int32 PartID { get; set; }
        public Int32 Price { get; set; }
        public Int32 PriceQty { get; set; }
        public Int32 PriceUnit { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Abbrevation { get; set; }
        public string Stockable { get; set; }
        public string Retunable { get; set; }
        public Int32 PositionID { get; set; }
        public string Location { get; set; }
        public string lastupdatedDate { get; set; }

    }
}
