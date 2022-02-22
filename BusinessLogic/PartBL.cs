using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
  public  class PartBL
    {
          PartDB obj= new PartDB();

        public List<CompatibilityTrans> CompatibilityPart()
        {
           // PartDB _PartTypeDB = new PartTypeDB();
            List<CompatibilityTrans> _CompatibilityTrans = new List<CompatibilityTrans>();
            somaEntities _EFEntities = new somaEntities();
            _CompatibilityTrans = obj.CompatibilityPart(_EFEntities);
            return _CompatibilityTrans;

        }
        //public PartTypeBO PopulateViewData()
        //{
        //    PartTypeBO viewData = new PartTypeBO();

        //    PartTypeDB _PartTypeDB = new PartTypeDB();
        //    somaEntities _EFEntities = new somaEntities();

        //    List<PartTypeBO> dbPartTypes;

        //    try
        //    {
        //        viewData = new PartTypeBO();

        //        dbPartTypes = _PartTypeDB.GetAllPartTypes(_EFEntities);
        //        if (dbPartTypes != null && dbPartTypes.Count > 0)
        //        {
        //            viewData.DDLPartTypes = dbPartTypes;
        //            viewData.PartTypeGridData = dbPartTypes;
        //        }

        //        return viewData;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null/* TODO Change to default(_) if this is not a reference type */;
        //    }
        //    finally
        //    {
        //     //   PartTypeDB.Dispose();
        //    }
        //}


        public string CreatePart(PartBO _PartBO)
        {
            // log4net.GlobalContext.Properties("HSProRepairUserName") = TestGlobal.UserName

          //   PartTypeDBOps _PartTypeDBOps = new PartTypeDBOps();
             somaEntities _EFEntities = new somaEntities();
            PartDB _PartDB = new PartDB();

            string CreateStatus;

            try
            {
                //foreach (var obj in vPartTypes)
                //{
                //    obj.PartTypeDescription ="test1" ;
                //    obj.CreatedBy = 1;
                //  //  obj.CreatedDate = DateTime.Now();
                //}

                   _PartDB.CreatePart(_PartBO, _EFEntities);
                return "";
            }
            catch (Exception ex)
            {
                return "Exception";
            }
            finally
            {
                //_PartTypeDBOps.Dispose();
            }
        }
        public string ValidatePartTypeDesc(int pPartTypeID, string pPartTypeDesc)
        {
            PartTypeDB _PartTypeDBOps = new PartTypeDB();
            somaEntities _EFEntities = new somaEntities();
            string validationStatus;

            try
            {
                validationStatus = _PartTypeDBOps.ValidateDescription(pPartTypeID, pPartTypeDesc, _EFEntities);
                return (validationStatus);
            }
            catch (Exception ex)
            {
                return ("Exception");
            }
            finally
            {
                _PartTypeDBOps.Dispose();
            }
        }

      
    }
}
