using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic
{
 public   class CommonMasterBL
    {
        CommonMasterDB obj = new CommonMasterDB();

        public List<VendorTypeBO> GetAllAbbrevation()
        {
            CommonMasterDB _obj = new CommonMasterDB();
            List<VendorTypeBO> _VendorTypeBO = new List<VendorTypeBO>();

            somaEntities _EFEntities = new somaEntities();
            _VendorTypeBO = _obj.GetAllAbbrevation();
            return _VendorTypeBO;

        }

        public List<VendorBO> GetAllSupplier(string Abb)
        {
            CommonMasterDB _obj = new CommonMasterDB();
            List<VendorBO> _VendorTypeBO = new List<VendorBO>();

          //  somaEntities _EFEntities = new somaEntities();
            _VendorTypeBO = _obj.GetAllSupplier(Abb);
            return _VendorTypeBO;

        }
        public List<PartTypeBO> GetAllPartType()
        {
            PartTypeDB _PartTypeDB = new PartTypeDB();
            List<PartTypeBO> _PartTypeBO = new List<PartTypeBO>();
            somaEntities _EFEntities = new somaEntities();
            _PartTypeBO = _PartTypeDB.GetAllPartType(_EFEntities);
            return _PartTypeBO;

        }
        public List<SubTypeBO> GetAllSubPartType(Int32 PartTypeID)
        {
          //  PartTypeDB _PartTypeDB = new PartTypeDB();
            List<SubTypeBO> _SubTypeBO = new List<SubTypeBO>();
            somaEntities _EFEntities = new somaEntities();
            _SubTypeBO = obj.GetAllSubPartType(PartTypeID,_EFEntities);
            return _SubTypeBO;

        }
    }
}
