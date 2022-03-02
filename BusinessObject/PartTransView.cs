using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class PartTransView

    {
        public string chk { get; set; }
        public Int32 PartID { get; set; }
        public Int32 PartTypeID { get; set; }
        public Int32 SubTypeID { get; set; }
        public string Active { get; set; }
        public string FirstName { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string PartNo { get; set; }
        public string PartDescription { get; set; }
        public Int32 GrossWeight { get; set; }
        public Int32 Dim_L { get; set; }
        public Int32 Dim_H { get; set; }
        public bool Stockable { get; set; }
        public string OnlineMsg { get; set; }
        public string Note { get; set; }
        public Int32 StatusId { get; set; }
        public bool Returnable { get; set; }
        public bool Publish { get; set; }
        public string PartTypeDescription { get; set; }
        public string SubTypeDescription { get; set; }
        public string Supplier { get; set; }
        public string Compatibility { get; set; }
        public string AlternatePart { get; set; }
        public string RelatedPart { get; set; }
        public string PartConditionPrice { get; set; }
        public string PartLogistics { get; set; }
        public string Statusname { get; set; }
        public string Retrofitted { get; set; }
        public string Replacement { get; set; }
        public string Exchange { get; set; }


    }

}
