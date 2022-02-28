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
  public  class PartCompatibilityDB
    {

        log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<BusinessObject.PartCompatibilityBO> GetPartCompatibility(somaEntities pDBOps)
            {
                List<BusinessObject.PartCompatibilityBO> dbPartLinks;

                try
                {
                    dbPartLinks = (from partLink in pDBOps.v_PartsCompatibility
                                   orderby partLink.ProductCategoryDescription
                                   select new BusinessObject.PartCompatibilityBO()
                                   {
                                       PartLinkID = partLink.PartLinkID,
                                       PartID = partLink.PartID,
                                       ProductCategoryID = partLink.ProductCategoryID,
                                       ProductCategoryDescription = partLink.ProductCategoryDescription,
                                       VendorID = partLink.VendorID,
                                       VendorName = partLink.VendorName,
                                       ModelID = partLink.ModelID,
                                       ModelNo = partLink.ModelNo,
                                       ModelManufacturerId = partLink.ModelManufacturerId,
                                       Active = partLink.Active,
                                       CreatedBy = partLink.CreatedBy,
                                       UserName = partLink.UserName,
                                       CreatedDate = partLink.CreatedDate,
                                       ModifiedBy = partLink.ModifiedBy,
                                       ModifiedDate = partLink.ModifiedDate
                                   }).ToList();

                    if (dbPartLinks != null && dbPartLinks.Count > 0)
                        return dbPartLinks;
                    else
                        return null;
                }
                catch (Exception ex)
                {
                
        log.Error("AN exception occured while reading Part Compatibility!!!");
                    return null;
                }
            }

            public BusinessObject.PartCompatibilityDDLValuesBO PopulateCompatibilityDDLs(somaEntities pDBOps)
            {
            BusinessObject.PartCompatibilityDDLValuesBO objCompatibilityDDL;

                List<M_Model> dbModelsForCategory;
                M_ModelManufacturer dbModelManufacturer;
                M_Vendor dbVendor;

            // Dim dbCompRecords As List(Of v_PartsCompatibility)
            // Dim dbCompRecordsForCategory As List(Of v_PartsCompatibility)
            // Dim dbCompRecordForCatMan As v_PartsCompatibility

            // Dim dbProdCategory As Infrastructure.ProductCategory
            BusinessObject.ManufacturerBO dbCatManufactuere;

                List<BusinessObject.ProductCategoryBO> dbProdCategories;
                List<BusinessObject.ManufacturerBO> dbManufacturers;
                List<BusinessObject.ModelBO> dbModels;

                // Dim DistinctCategories As List(Of String)
                // Dim DistinctManWithinCat As List(Of String)

                try
                {
                    objCompatibilityDDL = new BusinessObject.PartCompatibilityDDLValuesBO();
                    objCompatibilityDDL.ProductCategories = new List<BusinessObject.ProductCategoryBO>();
                    objCompatibilityDDL.Manufacturers = new List<BusinessObject.ManufacturerBO>();
                    objCompatibilityDDL.Models = new List<BusinessObject.ModelBO>();

                    dbProdCategories = (from cat in pDBOps.M_ProductCategory
                                        where cat.Active == true
                                        orderby cat.ProductCategoryDescription
                                        select new BusinessObject.ProductCategoryBO()
                                        {
                                            ProductCategoryID = cat.ProductCategoryID,
                                            ProductCategoryDescription = cat.ProductCategoryDescription,
                                            Active = cat.Active
                                        }).ToList();
                    if (dbProdCategories != null && dbProdCategories.Count > 0)
                        objCompatibilityDDL.ProductCategories.AddRange(dbProdCategories);

                    if (dbProdCategories != null && dbProdCategories.Count > 0)
                    {
                        foreach (var prodCat in dbProdCategories)
                        {
                            dbModelsForCategory = (from prod in pDBOps.M_Model
                                                   where prod.Active == true & prod.ProductCategoryID == prodCat.ProductCategoryID
                                                   orderby prod.ModelNo
                                                   select prod).ToList();
                            if (dbModelsForCategory != null && dbModelsForCategory.Count > 0)
                            {
                                foreach (var prod in dbModelsForCategory)
                                {
                                    dbModelManufacturer = (from modMan in pDBOps.M_ModelManufacturer
                                                           where modMan.ModelID == prod.ModelID
                                                           select modMan).FirstOrDefault();
                                    dbVendor = (from ven in pDBOps.M_Vendor
                                                where ven.VendorID == dbModelManufacturer.VendorID & ven.Active == true 
                                                select ven).FirstOrDefault();
                                    dbCatManufactuere = new BusinessObject.ManufacturerBO();
                                    {
                                        var withBlock = dbCatManufactuere;
                                        withBlock.ProductCategoryID = prod.ProductCategoryID;
                                        withBlock.VendorID = dbModelManufacturer.VendorID;
                                        withBlock.VendorName = dbVendor.VendorName;
                                    }
                                    objCompatibilityDDL.Manufacturers.Add(dbCatManufactuere);
                                    dbCatManufactuere = null/* TODO Change to default(_) if this is not a reference type */;
                                }
                            }
                        }
                    }

                    dbModels = (from manProd in pDBOps.M_ModelManufacturer
                                join prod in pDBOps.M_Model on manProd.ModelID equals prod.ModelID
                                where prod.Active == true & manProd.Active == true
                                orderby prod.ModelNo
                                select new BusinessObject.ModelBO()
                                {
                                    VendorID = manProd.VendorID,
                                    ModelID = manProd.ModelID,
                                    ModelNo = prod.ModelNo,
                                    Active = prod.Active
                                }).ToList();
                    if (dbModels != null && dbModels.Count > 0)
                        objCompatibilityDDL.Models.AddRange(dbModels);

                    if (objCompatibilityDDL != null)
                        return objCompatibilityDDL;
                    else
                        return null/* TODO Change to default(_) if this is not a reference type */;
                }
                catch (Exception ex)
                {
                   // log.Error("AN exception occured while reading Part Compatibility!!!");
                    return null/* TODO Change to default(_) if this is not a reference type */;
                }
            }

            public List<BusinessObject.PartCompatibilityBO> GetPartCompatibility(int pPartID, somaEntities pDBOps)
            {
                List<BusinessObject.PartCompatibilityBO> dbPartLinks;

                try
                {
                    dbPartLinks = (from partLink in pDBOps.v_PartsCompatibility
                                   where partLink.PartID == pPartID
                                   orderby partLink.ProductCategoryDescription
                                   select new BusinessObject.PartCompatibilityBO()
                                   {
                                       PartLinkID = partLink.PartLinkID,
                                       PartID = partLink.PartID,
                                       ProductCategoryID = partLink.ProductCategoryID,
                                       ProductCategoryDescription = partLink.ProductCategoryDescription,
                                       VendorID = partLink.VendorID,
                                       VendorName = partLink.VendorName,
                                       ModelID = partLink.ModelID,
                                       ModelNo = partLink.ModelNo,
                                       ModelManufacturerId = partLink.ModelManufacturerId,
                                       Active = partLink.Active,
                                       CreatedBy = partLink.CreatedBy,
                                       UserName = partLink.UserName,
                                       CreatedDate = partLink.CreatedDate,
                                       ModifiedBy = partLink.ModifiedBy,
                                       ModifiedDate = partLink.ModifiedDate
                                   }).ToList();

                    if (dbPartLinks != null && dbPartLinks.Count > 0)
                        return dbPartLinks;
                    else
                        return null;
                }
                catch (Exception ex)
                {
                  //  log.Error("AN exception occured while reading Part Compatibility!!!");
                    return null;
                }
            }

            public List<BusinessObject.ProductCategoryBO> GetProductCategories(somaEntities pDBOps)
            {
                List<BusinessObject.ProductCategoryBO> dbProdCategories;

                try
                {
                    dbProdCategories = (from prodCat in pDBOps.M_ProductCategory
                                        where prodCat.Active == true
                                        orderby prodCat.ProductCategoryDescription
                                        select new BusinessObject.ProductCategoryBO()
                                        {
                                            ProductCategoryID = prodCat.ProductCategoryID,
                                            ProductCategoryDescription = prodCat.ProductCategoryDescription,
                                            Active = prodCat.Active,
                                            CreatedBy = prodCat.CreatedBy,
                                            CreatedDate = prodCat.CreatedDate,
                                            ModifiedBy = prodCat.ModifiedBy,
                                            ModifiedDate = prodCat.ModifiedDate
                                        }).ToList();
                    if (dbProdCategories != null && dbProdCategories.Count > 0)
                        return dbProdCategories;
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            public List<BusinessObject.ManufacturerBO> GetManufacturers(somaEntities pDBOps)
            {
                List<BusinessObject.ManufacturerBO> dbManufacturer;

                try
                {
                    dbManufacturer = (from man in pDBOps.M_Vendor
                                      orderby man.VendorName
                                      select new BusinessObject.ManufacturerBO()
                                      {
                                          VendorID = man.VendorID,
                                          VendorName = man.VendorName,
                                          Active = man.Active,
                                          CreatedBy = man.CreatedBy,
                                          CreatedDate = man.CreatedDate,
                                          ModifiedBy = man.ModifiedBy,
                                          ModifiedDate = man.ModifiedDate
                                      }).ToList();
                    if (dbManufacturer != null && dbManufacturer.Count > 0)
                        return dbManufacturer;
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            public List<BusinessObject.ModelBO> GetModels(somaEntities pDBOps)
            {
                List<BusinessObject.ModelBO> dbModel;

                try
                {
                    dbModel = (from man in pDBOps.M_Model
                               orderby man.ModelNo
                               select new BusinessObject.ModelBO()
                               {
                                   ModelID = man.ModelID,
                                   ModelNo = man.ModelNo,
                                   Active = man.Active,
                                   CreatedBy = man.CreatedBy,
                                   CreatedDate = man.CreatedDate,
                                   ModifiedBy = man.ModifiedBy,
                                   ModifiedDate = man.ModifiedDate
                               }).ToList();
                    if (dbModel != null && dbModel.Count > 0)
                        return dbModel;
                    else
                        return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        
    }
}
