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
        public string PartNo { get; set; }
        public string PartDescription { get; set; }

        public string PartDetailDescription { get; set; }

        public Int32 GrossWeight { get; set; }

        public Int32 Dim_L { get; set; }

        public Int32 Dim_W { get; set; }
        public Int32 Dim_H { get; set; }
        public bool Stockable { get; set; }
        public string OnlineMsg { get; set; }
        public string Note { get; set; }


        

    }
}
