using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
  public  class PartCompatibilityBL
    {

        
            //public Infrastructure.TestView PopulateViewData()
            //{
            //    Infrastructure.TestView viewData;

            //    PartTypeDBOps _PartTypeDBOps = new PartTypeDBOps();
            //    somaEntities _EFEntities = new SOMAEntities();

            //    List<Infrastructure.PartType> dbPartTypes;

            //    try
            //    {
            //        viewData = new TestView();

            //        dbPartTypes = _PartTypeDBOps.GetAllPartTypes(_EFEntities);
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
            //        _PartTypeDBOps.Dispose();
            //    }
            //}

            public List<BusinessObject.PartCompatibilityBO> GetPartCompatibilities()
            {
                List<BusinessObject.PartCompatibilityBO> partCompRecords;

                PartCompatibilityDB _PartCompatibilityDB = new PartCompatibilityDB();
                somaEntities _EFEntities = new somaEntities();

                try
                {
                    partCompRecords = new List<BusinessObject.PartCompatibilityBO>();
                    partCompRecords = _PartCompatibilityDB.GetPartCompatibility(_EFEntities);

                    if (partCompRecords != null && partCompRecords.Count > 0)
                        return partCompRecords;
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            public List<BusinessObject.PartCompatibilityBO> GetPartCompatibilities(int pPartID)
            {
                List<BusinessObject.PartCompatibilityBO> partCompRecords;

            PartCompatibilityDB _PartCompatibilityDB = new PartCompatibilityDB();
            somaEntities _EFEntities = new somaEntities();

                try
                {
                    partCompRecords = new List<BusinessObject.PartCompatibilityBO>();
                    partCompRecords = _PartCompatibilityDB.GetPartCompatibility(pPartID, _EFEntities);

                    if (partCompRecords != null && partCompRecords.Count > 0)
                        return partCompRecords;
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            public BusinessObject.PartCompatibilityDDLValuesBO PopulateCompatibilityDDLs()
            {
            BusinessObject.PartCompatibilityDDLValuesBO objCompDDL;

            PartCompatibilityDB _PartCompatibilityDB = new PartCompatibilityDB();
            somaEntities _EFEntities = new somaEntities();
                try
                {
                    objCompDDL = _PartCompatibilityDB.PopulateCompatibilityDDLs(_EFEntities);
                    return objCompDDL;
                }
                catch (Exception ex)
                {
                    return null/* TODO Change to default(_) if this is not a reference type */;
                }
            }
        
    }
}
