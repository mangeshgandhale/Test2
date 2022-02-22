﻿using BusinessObject;
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
 public class PartDB
    {
        private somaEntities _context;
        public PartDB()
        {
            somaEntities _CContext = new somaEntities();
            this._context = _CContext;
        }
        //public List<M_PartType> GetAllPartList()
        //{
        //    return _context.M_PartType.ToList();
        //}
          
        public void CreatePart(PartBO _PartBO, somaEntities pDBOps)
        {
            using (somaEntities db = new somaEntities())
            {
                var _objTPart = new T_Part()
                { PartID = 0,
                    SubTypeID= _PartBO.SubTypeID,
                    ReplacementPartID = _PartBO.ReplacementPartID,
                    PartNo = _PartBO.PartNo,
                    PartDescription = _PartBO.PartDescription,
                    PartDetailDescription = _PartBO.PartDetailDescription,
                    Dim_H = _PartBO.Dim_H,
                    Dim_W = _PartBO.Dim_W,
                    Dim_L = _PartBO.Dim_L,
                    GrossWeight = _PartBO.GrossWeight,
                    OnlineMsg = _PartBO.OnlineMsg,
                    Note = _PartBO.Note,
                    Active = true,
                    Stockable = true,
                    StatusId = 4,
                    CreatedBy =1,
                    Returnable= true,
                    CreatedDate=DateTime.Now,
                    Publish = true

                };
                db.T_Part.Add(_objTPart);

                db.SaveChanges();
               

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



        //public List<PartTypeBO> GetAllPartTypes(somaEntities pDBOps)
        //{
        //    List<PartTypeBO> dbPartTypes = new List<PartTypeBO>();

        //    try
        //    {
        //        //dbPartTypes = (from partType in pDBOps.M_PartType
        //        //               orderby partType.PartTypeID
        //        //               select new PartTypeBO()
        //        //               {
        //        //                   PartTypeID = partType.PartTypeID,
        //        //                   PartTypeDescription = partType.PartTypeDescription,
        //        //                   Active = partType.Active,

        //        //               }).ToList();
               
        //            DataTable dt = new DataTable();
        //        SqlParameterCollection pcol = new SqlCommand().Parameters;
        //        Data.Adapter.AddParam(pcol, "@PartTypeID",0);
        //        dt = Data.Adapter.ExecuteDataTable("uspviewPartType", CommandType.StoredProcedure, Data.Adapter.param(pcol));

        //      //  dt = Adapter.ExecuteDataTable("select * from M_PartType", CommandType.Text);
        //        if (dt.Rows.Count > 0)
        //        {
                     
        //            dbPartTypes = MVC3Layer.common.CommonFunction.ToListof<PartTypeBO>(dt);

        //        }

        //       // if (dbPartTypes != null && dbPartTypes.Count > 0)
        //            return dbPartTypes;
        //       // else
        //        //    return null;
        //    }
        //    catch (Exception ex)
        //    {
        //      //  log.Error("AN exception occured while reading Part Types!!!");
        //        return null;
        //    }
        //}
        //public string CreateNewPart(List<PartTypeBO> vPartTypes, somaEntities pDBOps)
        //{
        //    // log4net.GlobalContext.Properties("HSProRepairUserName") = TestGlobal.UserName
        //    List<M_PartType> dbPartTypes = new List<M_PartType>();
        //    M_PartType dbPartType;

        //    try
        //    {
        //        foreach (var partType in vPartTypes)
        //        {
        //            dbPartType = new M_PartType();
        //            {
        //                var withBlock = dbPartType;
        //                withBlock.PartTypeDescription = partType.PartTypeDescription;
        //                withBlock.Active = partType.Active;
        //                withBlock.CreatedBy = 1;
        //                withBlock.CreatedDate = partType.CreatedDate;
        //            }
        //            dbPartTypes.Add(dbPartType);
        //        }
        //        pDBOps.M_PartType.AddRange(dbPartTypes);
        //        pDBOps.SaveChanges();

        //        return ("Success");
        //    }
        //    catch (Exception ex)
        //    {
        //     //   log.Error("An exception occured while creating Part Type", ex);
        //        return ("Exception");
        //    }
        //    finally
        //    {
        //        dbPartTypes = null;
        //        dbPartType = null/* TODO Change to default(_) if this is not a reference type */;
        //        pDBOps.Dispose();
        //    }
        //}

        //public string ValidateDescription(int pPartTypeID, string pPartTypeDesc, somaEntities pDBOps)
        //{
        //    M_PartType dbPartType;

        //    try
        //    {
        //        dbPartType = (from pType in pDBOps.M_PartType
        //                      where pType.PartTypeDescription == pPartTypeDesc
        //                      select pType).FirstOrDefault();
        //        if (dbPartType != null)
        //            return ("Duplicate");
        //        else
        //            return ("Unique");
        //    }
        //    catch (Exception ex)
        //    {
        //        return ("Exception");
        //    }
        //    finally
        //    {
        //        dbPartType = null/* TODO Change to default(_) if this is not a reference type */;
        //    }
        //}


    }
}
