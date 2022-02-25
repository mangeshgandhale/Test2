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
    public class CommonMasterDB
    {
        private somaEntities _context;
        public CommonMasterDB()
        {
            somaEntities _CContext = new somaEntities();
            this._context = _CContext;
        }



        public List<VendorBO> GetAllSupplier(string Abb)
        {
            List<VendorBO> _VendorBO = new List<VendorBO>();

            DataTable dt = new DataTable(); 

            SqlParameterCollection pcol = new SqlCommand().Parameters;
            Data.Adapter.AddParam(pcol, "@VendorID", 0);
            Data.Adapter.AddParam(pcol, "@VendorTypeID", 0);
            Data.Adapter.AddParam(pcol, "@Abb", Abb);
            Data.Adapter.AddParam(pcol, "@VendorName", "");


            dt = Data.Adapter.ExecuteDataTable("uspviewVendor", CommandType.StoredProcedure, Data.Adapter.param(pcol));

            if (dt.Rows.Count > 0)
            {
                _VendorBO = MVC3Layer.common.CommonFunction.ToListof<VendorBO>(dt);
            }
            return _VendorBO;
        }

        public List<VendorTypeBO> GetAllAbbrevation()
        {
            List<VendorTypeBO> _VendorTypeBO = new List<VendorTypeBO>();

            DataTable dt = new DataTable();
            SqlParameterCollection pcol = new SqlCommand().Parameters;

            dt = Data.Adapter.ExecuteDataTable("dbo.uspBindAbbrevation", CommandType.StoredProcedure, Data.Adapter.param(pcol));


            if (dt.Rows.Count > 0)
            {
                _VendorTypeBO = MVC3Layer.common.CommonFunction.ToListof<VendorTypeBO>(dt);
            }
            return _VendorTypeBO;
        }

        public List<SubTypeBO> GetAllSubPartType(Int32 PartTypeID, somaEntities pDBOps)
        {
            List<SubTypeBO> _obj = new List<SubTypeBO>();

            try
            {
                _obj = (from _o in pDBOps.M_SubType
                        orderby _o.PartTypeID
                        select new SubTypeBO()
                        {
                            SubTypeID = _o.SubTypeID,
                            SubTypeDescription = _o.SubTypeDescription,
                            Active = _o.Active,
                            // }).Where(p => p.Active == true && p.PartTypeID == PartTypeID).ToList();
                        }).Where(p => p.Active == true).ToList();




                return _obj;

            }
            catch (Exception ex)
            {
                //  log.Error("AN exception occured while reading Part Types!!!");
                return null;
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
