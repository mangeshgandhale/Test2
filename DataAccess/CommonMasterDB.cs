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
 public   class CommonMasterDB
    {
        private somaEntities _context;
        public CommonMasterDB()
        {
            somaEntities _CContext = new somaEntities();
            this._context = _CContext;
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
