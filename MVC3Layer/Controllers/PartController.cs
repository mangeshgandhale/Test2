using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;
using System.IO;
using System.Web.Hosting;
using Kendo.Mvc.UI;

namespace MVC3Layer.Controllers
{
    public class PartController : Controller
    {


        string photoPath = Path.Combine(HostingEnvironment.MapPath("~/Images"), "profile_photo.png");
        // GET: Part

        public ActionResult Remote_Binding_Orders_Read([DataSourceRequest] DataSourceRequest request)
        {
            PartBL _PartBL = new PartBL();
            List<CompatibilityTrans> _CompatibilityTrans = new List<CompatibilityTrans>();
            _CompatibilityTrans = _PartBL.CompatibilityPart(0);

            DataSourceResult result = new DataSourceResult();
            result.Data = _CompatibilityTrans;
            result.Total = _CompatibilityTrans.Count;

            return Json(result, "application/json", JsonRequestBehavior.AllowGet);

        }

        public ActionResult PartAdd()
        {
            List<CompatibilityTrans> _CompatibilityTrans = new List<CompatibilityTrans>();
            List<PartTypeBO> _PartTypeBO = new List<PartTypeBO>();
            PartTypeBL _PartTypeBL = new PartTypeBL();
            _PartTypeBO = _PartTypeBL.GetAllPartType();
            ViewBag.lstPartType = _PartTypeBO;
            ViewBag.Photo = System.IO.File.Exists(photoPath) ? "/images/profile_photo.png" : "/images/profile_default.png";

            PartBL _PartBL = new PartBL();
            ViewBag.lstCompatibilityPart = _PartBL.CompatibilityPart(0);

             _CompatibilityTrans = _PartBL.CompatibilityPart(0);
            ViewBag.lstRelatedPartTrans = _PartBL.RelatedPartTrans(0);
            ViewBag.lstSupplierTrans = _PartBL.SupplierTrans(64);
            ViewBag.lstConditionPriceTrans = _PartBL.ConditionPriceTrans(0);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PartAdd(FormCollection collection)
        //public ActionResult PartAdd(BusinessObject.PartBO _PartBO)
        {
            PartBL PartBL = new PartBL();
            BusinessObject.PartBO _PartBO= new PartBO();
            try
            {
               // PartBL.CreatePart(_PartBO);
                return Json("");
            }
            catch (Exception ex)
            {
                return Json("");
            }
            finally
            {
                //   partTypeBL.Dispose();
            }
            //if (!ModelState.IsValid)
            //{
            //    return View(_PartBO);
            //}
            //else
            //{
            //    TempData["View"] = "Overview";
            //    return View("Success");
            //}
        }


        public ActionResult Savephoto(HttpPostedFileBase Photo)
        {
            if (Photo != null)
            {
                Photo.SaveAs(photoPath);
            }
            return PartAdd();
        }
        public JsonResult TypeGetData()
        {
            List<PartTypeBO> _PartTypeBO = new List<PartTypeBO>();
            PartTypeBL _PartTypeBL = new PartTypeBL();
            _PartTypeBO= _PartTypeBL.GetAllPartType();            
            ViewBag.lstPartType = _PartTypeBO;            
            return Json(_PartTypeBO, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllSubPartType()
        {            
            List<SubTypeBO> _SubTypeBO = new List<SubTypeBO>();
            CommonMasterBL _objBL = new CommonMasterBL();
            _SubTypeBO = _objBL.GetAllSubPartType(0); 
            return Json(_SubTypeBO, JsonRequestBehavior.AllowGet);
        }
    }
}