using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class ProductCategoryBO:AuditControl
    {
        public int ProductCategoryID { get; set; }
        public string ProductCategoryDescription { get; set; }
        public bool Active { get; set; }
    }
}
