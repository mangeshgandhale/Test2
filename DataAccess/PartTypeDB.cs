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
 public class PartTypeDB
    {
        private somaEntities _context;
        public PartTypeDB()
        {
            somaEntities _CContext = new somaEntities();
            this._context = _CContext;
        }
        public List<M_PartType> GetAllPartList()
        {
            return _context.M_PartType.ToList();
        }
          
        public void Insert(PartTypeBO _PartTypeBO)
        {

            using (somaEntities db = new somaEntities())
            {



                var M_PartType = new M_PartType()
                {
                    PartTypeID = _PartTypeBO.PartTypeID,
                    PartTypeDescription = _PartTypeBO.PartTypeDescription,
                    Active = true,
                    CreatedBy=1
                   
                };
                db.M_PartType.Add(M_PartType);

                db.SaveChanges();


            }





            //db.SaveChanges()

            //db.UserBO.Add(_UserBO);
            //using (var context = new Model1())
            //{
            //    var std = context..First<Student>();
            //    std.FirstName = "Steve";
            //    context.SaveChanges();
            //}
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



        public List<PartTypeBO> GetAllPartTypes(somaEntities pDBOps)
        {
            List<PartTypeBO> dbPartTypes = new List<PartTypeBO>();

            try
            {
                //dbPartTypes = (from partType in pDBOps.M_PartType
                //               orderby partType.PartTypeID
                //               select new PartTypeBO()
                //               {
                //                   PartTypeID = partType.PartTypeID,
                //                   PartTypeDescription = partType.PartTypeDescription,
                //                   Active = partType.Active,

                //               }).ToList();
               
                    DataTable dt = new DataTable();
                SqlParameterCollection pcol = new SqlCommand().Parameters;
                Data.Adapter.AddParam(pcol, "@PartTypeID",0);
                dt = Data.Adapter.ExecuteDataTable("uspviewPartType", CommandType.StoredProcedure, Data.Adapter.param(pcol));

              //  dt = Adapter.ExecuteDataTable("select * from M_PartType", CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                     
                    dbPartTypes = MVC3Layer.common.CommonFunction.ToListof<PartTypeBO>(dt);

                }

               // if (dbPartTypes != null && dbPartTypes.Count > 0)
                    return dbPartTypes;
               // else
                //    return null;
            }
            catch (Exception ex)
            {
              //  log.Error("AN exception occured while reading Part Types!!!");
                return null;
            }
        }
        public string CreateNewPart(List<PartTypeBO> vPartTypes, somaEntities pDBOps)
        {
            // log4net.GlobalContext.Properties("HSProRepairUserName") = TestGlobal.UserName
            List<M_PartType> dbPartTypes = new List<M_PartType>();
            M_PartType dbPartType;

            try
            {
                foreach (var partType in vPartTypes)
                {
                    dbPartType = new M_PartType();
                    {
                        var withBlock = dbPartType;
                        withBlock.PartTypeDescription = partType.PartTypeDescription;
                        withBlock.Active = partType.Active;
                        withBlock.CreatedBy = 1;
                        withBlock.CreatedDate = partType.CreatedDate;
                    }
                    dbPartTypes.Add(dbPartType);
                }
                pDBOps.M_PartType.AddRange(dbPartTypes);
                pDBOps.SaveChanges();

                return ("Success");
            }
            catch (Exception ex)
            {
             //   log.Error("An exception occured while creating Part Type", ex);
                return ("Exception");
            }
            finally
            {
                dbPartTypes = null;
                dbPartType = null/* TODO Change to default(_) if this is not a reference type */;
                pDBOps.Dispose();
            }
        }

        public string ValidateDescription(int pPartTypeID, string pPartTypeDesc, somaEntities pDBOps)
        {
            M_PartType dbPartType;

            try
            {
                dbPartType = (from pType in pDBOps.M_PartType
                              where pType.PartTypeDescription == pPartTypeDesc
                              select pType).FirstOrDefault();
                if (dbPartType != null)
                    return ("Duplicate");
                else
                    return ("Unique");
            }
            catch (Exception ex)
            {
                return ("Exception");
            }
            finally
            {
                dbPartType = null/* TODO Change to default(_) if this is not a reference type */;
            }
        }


    }
}
