using BusinessObject;
using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class PartSupplierTransDB
    {


        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<BusinessObject.SupplierTransBO> GetPartSupplierTranslist(int PartID, somaEntities pDBOps)
        {
            // List<BusinessObject.SupplierTransBO> dbPartLinks;

            try
            {
                List<BusinessObject.SupplierTransBO> _SupplierTrans = new List<BusinessObject.SupplierTransBO>();

                DataTable dt = new DataTable();

                SqlParameterCollection pcol = new SqlCommand().Parameters;
                Data.Adapter.AddParam(pcol, "@PartID", PartID);
                Data.Adapter.AddParam(pcol, "@SupplierNameSearch", "");
                Data.Adapter.AddParam(pcol, "@VendorID", 0);
                dt = Data.Adapter.ExecuteDataTable("uspviewSupplierTrans", CommandType.StoredProcedure, Data.Adapter.param(pcol));
                if (dt.Rows.Count > 0)
                {
                    _SupplierTrans = MVC3Layer.common.CommonFunction.ToListof<BusinessObject.SupplierTransBO>(dt);
                }

                if (_SupplierTrans != null && _SupplierTrans.Count > 0)
                    return _SupplierTrans;
                else
                    return null;
            }
            catch (Exception ex)
            {

                log.Error("AN exception occured while reading Part Compatibility!!!");
                return null;
            }
        }
        public List<BusinessObject.VendorTypeBO> GetAbbrevation(somaEntities pDBOps)
        {
            CommonMasterDB _obj = new CommonMasterDB();
            List<VendorTypeBO> _VendorTypeBO = new List<VendorTypeBO>();

            somaEntities _EFEntities = new somaEntities();
            _VendorTypeBO = _obj.GetAllAbbrevation();
            return _VendorTypeBO;

        }

        public List<BusinessObject.VendorBO> GetManufacture(somaEntities pDBOps)
        {
            CommonMasterDB _obj = new CommonMasterDB();
            List<VendorBO> _ManufacturerBO = new List<VendorBO>();

            somaEntities _EFEntities = new somaEntities();
            _ManufacturerBO = _obj.GetAllSupplier("");
            return _ManufacturerBO;

        }
        public BusinessObject.PartSupplierDDLValuesBO PopulateSupplierDDLs(somaEntities pDBOps)
        {

            List<BusinessObject.VendorBO> _Manufacture = GetManufacture(pDBOps);
            List<BusinessObject.VendorTypeBO> _Abbrevation = GetAbbrevation(pDBOps);
            BusinessObject.PartSupplierDDLValuesBO obj = new PartSupplierDDLValuesBO();
            obj.Manufacturers = _Manufacture;
            obj.VendorTypeBO = _Abbrevation;
            return obj;
        }
    }
}
