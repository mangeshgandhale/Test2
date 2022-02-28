using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
  public  class PartCompatibilityDDLValuesBO
    {

        public List<BusinessObject.ProductCategoryBO> ProductCategories { get; set; }
        public List<BusinessObject.ManufacturerBO> Manufacturers { get; set; }
        public List<BusinessObject.ModelBO> Models { get; set; }
    }
}
