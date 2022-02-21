using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserBO
    {

        public Int32 UserID { get; set; }

        public string FirstName { get; set; }

        public string lastName { get; set; }
        [Required]
      
        public string UserName { get; set; }

        [Required]
       
        public string password { get; set; }

        public string StatusID { get; set; }

        public string Active { get; set; }
        public string CreatedBy { get; set; }

        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }

        public string ModifiedDate { get; set; }
      
      
        public string UserEmail { get; set; }

  



                             
    }
}
