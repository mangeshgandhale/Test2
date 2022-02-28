using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using BusinessObject;

namespace MVC3Layer.Controllers
{
    public class SupplierTransController : Controller
    {
        // GET: SupplierTrans
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartSupplierTransList(int cPartID)
        {
            PartSupplierTransBL _Ops = new PartSupplierTransBL();
            List<BusinessObject.SupplierTransBO> dbPartCompRecords;

            dbPartCompRecords = _Ops.GetPartSupplierTranslist(0);

            return Json(dbPartCompRecords, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PopulateDDLTables()
        {
            BusinessObject.PartSupplierDDLValuesBO CompDDL;
            PartSupplierTransBL _Ops = new PartSupplierTransBL();

            try
            {
                CompDDL = _Ops.PopulateSupplierDDLs();

                var ResultCollection = new { Manufacturers = CompDDL.Manufacturers, ABB = CompDDL.VendorTypeBO };

                return Json(ResultCollection, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("");
            }
            finally
            {
                CompDDL = null/* TODO Change to default(_) if this is not a reference type */;
            }
        }

        public ActionResult LaunchSupplierWindow(List<BusinessObject.SupplierTransBO> cPartSupplierTransData)
        {
            try
            {
                return PartialView("_PartCompatibility", cPartSupplierTransData);
            }
            catch (Exception ex)
            {
                return Json("");
            }
        }
    }
}