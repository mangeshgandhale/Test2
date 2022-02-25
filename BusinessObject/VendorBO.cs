using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
  public  class VendorBO
    {


         public Int32 VendorID { get; set; }
        public string Abb { get; set; }
        public string VendorTypeDescription { get; set; }
        public Int32 VendorTypeID { get; set; }
        public string VendorName { get; set; }
        public bool Active { get; set; }
        public string FirstName { get; set; }
        public Int32 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string CountryId { get; set; }
        public string Countryname { get; set; }
        public string ContactPerson { get; set; }

        public string MobileNo1 { get; set; }

        public string MobileNo2 { get; set; }
       
        public string AccountNo { get; set; }
                 


    }
}
