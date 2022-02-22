using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;
namespace MVC3Layer.Controllers
{
    public class PartController : Controller
    {
        // GET: Part
        public ActionResult PartAdd()
        {
            //return View(new BusinessObject.PartBO()
            //{
            //    PartNo = "John",
            //  //  PartDescription = "Doe"

            //});
            List<PartTypeBO> _PartTypeBO = new List<PartTypeBO>();
            PartTypeBL _PartTypeBL = new PartTypeBL();
            _PartTypeBO = _PartTypeBL.GetAllPartType();
            ViewBag.lstPartType = _PartTypeBO;

            return View();
        }

        [HttpPost]
        public ActionResult PartAdd(BusinessObject.PartBO _PartBO)
        {
            PartBL PartBL = new PartBL();

            try
            {
                PartBL.CreatePart(_PartBO);
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