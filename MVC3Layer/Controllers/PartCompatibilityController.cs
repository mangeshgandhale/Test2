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
    public class PartCompatibilityController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPartCompatibilities(int cPartID)
        {
            PartCompatibilityBL _Ops = new PartCompatibilityBL();
            List<PartCompatibilityBO> dbPartCompRecords;

            dbPartCompRecords = _Ops.GetPartCompatibilities(42);

            return Json(dbPartCompRecords, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PopulateDDLTables()
        {
            BusinessObject.PartCompatibilityDDLValuesBO CompDDL;
            PartCompatibilityBL _Ops = new PartCompatibilityBL();

            try
            {
                CompDDL = _Ops.PopulateCompatibilityDDLs();

                var ResultCollection = new { ProductCategories = CompDDL.ProductCategories, Manufacturers = CompDDL.Manufacturers, Models = CompDDL.Models };

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

        public ActionResult LaunchCompatibilityWindow(List<BusinessObject.PartCompatibilityBO> cPartCompData)
        {
            try
            {
                return PartialView("_PartCompatibility", cPartCompData);
            }
            catch (Exception ex)
            {
                return Json("");
            }
        }
    }
}
