using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
   public class PartSupplierTransBL
    {
     

        public List<BusinessObject.SupplierTransBO> GetPartSupplierTranslist(int pPartID)
        {
            List<BusinessObject.SupplierTransBO> _SupplierTransBO;

            PartSupplierTransDB _PartSupplierTransDB = new PartSupplierTransDB();
            somaEntities _EFEntities = new somaEntities();

            try
            {
                _SupplierTransBO = new List<BusinessObject.SupplierTransBO>();
                _SupplierTransBO = _PartSupplierTransDB.GetPartSupplierTranslist(pPartID, _EFEntities);

                if (_SupplierTransBO != null && _SupplierTransBO.Count > 0)
                    return _SupplierTransBO;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public BusinessObject.PartSupplierDDLValuesBO PopulateSupplierDDLs()
        {
            BusinessObject.PartSupplierDDLValuesBO objCompDDL;

            PartSupplierTransDB _PartSupplierTransDB = new PartSupplierTransDB();
            somaEntities _EFEntities = new somaEntities();
            try
            {
                objCompDDL = _PartSupplierTransDB.PopulateSupplierDDLs(_EFEntities);
                return objCompDDL;
            }
            catch (Exception ex)
            {
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }
    }
}
