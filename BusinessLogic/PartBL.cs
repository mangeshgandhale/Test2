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

        public List<CompatibilityTrans> CompatibilityTransPart(Int32 PartID)
        {
           // PartDB _PartTypeDB = new PartTypeDB();
            List<CompatibilityTrans> _CompatibilityTrans = new List<CompatibilityTrans>();
            somaEntities _EFEntities = new somaEntities();
            _CompatibilityTrans = obj.CompatibilityTransPart(PartID,_EFEntities);
            return _CompatibilityTrans;

        }
        public List<RelatedPartTrans> RelatedPartTrans(Int32 PartID)
        {
            // PartDB _PartTypeDB = new PartTypeDB();
            List<RelatedPartTrans> _RelatedPartTrans = new List<RelatedPartTrans>();
            somaEntities _EFEntities = new somaEntities();
            _RelatedPartTrans = obj.RelatedPartTrans(PartID,_EFEntities);
            return _RelatedPartTrans;

        }
        public List<SupplierTrans> SupplierTrans(Int32 PartID)
        {
            // PartDB _PartTypeDB = new PartTypeDB();
            List<SupplierTrans> _SupplierTrans = new List<SupplierTrans>();
            somaEntities _EFEntities = new somaEntities();
            _SupplierTrans = obj.SupplierTrans(PartID, _EFEntities);
            return _SupplierTrans;

        }

        public List<ConditionPriceTrans> ConditionPriceTrans(Int32 PartID)
        {
            // PartDB _PartTypeDB = new PartTypeDB();
            List<ConditionPriceTrans> _ConditionPriceTrans = new List<ConditionPriceTrans>();
            somaEntities _EFEntities = new somaEntities();
            _ConditionPriceTrans = obj.ConditionPriceTrans(PartID, _EFEntities);
            return _ConditionPriceTrans;

        }

        public List<LogistickTrans> LogistickTrans(Int32 PartID)
        {
            // PartDB _PartTypeDB = new PartTypeDB();
            List<LogistickTrans> _LogistickTrans = new List<LogistickTrans>();
            somaEntities _EFEntities = new somaEntities();
            _LogistickTrans = obj.LogistickTrans(PartID, _EFEntities);
            return _LogistickTrans;

        }
        public Int32 CreatePart(PartBO _PartBO)
        {
            // log4net.GlobalContext.Properties("HSProRepairUserName") = TestGlobal.UserName

          //   PartTypeDBOps _PartTypeDBOps = new PartTypeDBOps();
             somaEntities _EFEntities = new somaEntities();
            PartDB _PartDB = new PartDB();

       //     string CreateStatus;

            try
            {
               

                _PartBO.PartID = _PartDB.CreatePart(_PartBO, _EFEntities);
                return _PartBO.PartID;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                //_PartTypeDBOps.Dispose();
            }
        }

        public void AddConditonPriceTrans(Int32 PartID, List<ConditionPriceTrans> _ConditionPriceTrans)
        {
            
            obj.AddConditonPriceTrans(PartID, _ConditionPriceTrans);
         
        }
        public void AddRelatedPartTrans(Int32 PartID, List<RelatedPartTrans> _RelatedPartTrans)
        {

            obj.AddRelatedPartTrans(PartID, _RelatedPartTrans);

        }

        public void AddLogistickTrans(Int32 PartID, List<LogistickTrans> _LogistickTrans)
        {

            obj.AddLogistickTrans(PartID, _LogistickTrans);

        }

        public void AddCompatibilityTrans(Int32 PartID, List<CompatibilityTrans> _CompatibilityTrans)
        {

            obj.AddCompatibilityTrans(PartID, _CompatibilityTrans);

        }

        public void AddSupplierTrans(Int32 PartID, List<SupplierTrans> _SupplierTrans)
        {

            obj.AddSupplierTrans(PartID, _SupplierTrans);

        }
        
             public List<PartTransView> BindPart(Int32 PartID)
        {
            // PartDB _PartTypeDB = new PartTypeDB();
            List<PartTransView> _PartTransView = new List<PartTransView>();
            //   somaEntities _EFEntities = new somaEntities();
            _PartTransView = obj.BindPart(PartID);
            return _PartTransView;

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

    }
}
