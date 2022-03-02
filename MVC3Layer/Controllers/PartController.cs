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
using System.Text;

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
            _CompatibilityTrans = _PartBL.CompatibilityTransPart(0);

            DataSourceResult result = new DataSourceResult();
            result.Data = _CompatibilityTrans;
            result.Total = _CompatibilityTrans.Count;

            return Json(result, "application/json", JsonRequestBehavior.AllowGet);

        }
        public ActionResult ViewPart()
        {
            PartBL _PartBL = new PartBL();
            List<PartTransView> _PartTransView = new List<PartTransView>();
            _PartTransView = _PartBL.BindPart(0);
            return View(_PartTransView);
        }
        public ActionResult PartAdd()
        {
            Int32 PartID = Convert.ToInt32( Request.QueryString["PartID"]);


            PartBL _PartBL = new PartBL();
            PartTransView _PartTransView = new PartTransView();
            _PartTransView = _PartBL.BindPart(PartID).FirstOrDefault();
            PartBO B = new PartBO();
            B.Dim_H = _PartTransView.Dim_H;
            B.Dim_L = _PartTransView.Dim_L;
            //B.Dim_W = _PartTransView.Dim_W;
            B.PartNo = _PartTransView.PartNo;

            System.Web.HttpContext.Current.Session["UserID"] = 14;
            //  List<CompatibilityTrans> _CompatibilityTrans = new List<CompatibilityTrans>();
            List<PartTypeBO> _PartTypeBO = new List<PartTypeBO>();
            PartTypeBL _PartTypeBL = new PartTypeBL();
            _PartTypeBO = _PartTypeBL.GetAllPartType();
            ViewBag.lstPartType = _PartTypeBO;
            ViewBag.Photo = System.IO.File.Exists(photoPath) ? "/images/profile_photo.png" : "/images/profile_default.png";

          //  PartBL _PartBL = new PartBL();
            CommonMasterBL _CommonMasterBL = new CommonMasterBL();
            ViewBag.lstCompatibilityPart = _PartBL.CompatibilityTransPart(PartID);            
            ViewBag.lstRelatedPartTrans = _PartBL.RelatedPartTrans(PartID);
            ViewBag.lstSupplierTrans = _PartBL.SupplierTrans(PartID);
            ViewBag.lstConditionPriceTrans = _PartBL.ConditionPriceTrans(PartID);
            ViewBag.lstlogisticksTrans = _PartBL.LogistickTrans(PartID);
          //  ViewBag.lstAbbrevation = _CommonMasterBL.GetAllAbbrevation();
          //  ViewBag.lstSupplier = _CommonMasterBL.GetAllSupplier("");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PartAdd(FormCollection collection)
         {
           
            PartBL PartBL = new PartBL();
            BusinessObject.PartBO _PartBO = new PartBO();           
            _PartBO.Publish = true;// Convert.ToBoolean(collection["Publish"]);
            _PartBO.Note = Convert.ToString(collection["Note"]);
            _PartBO.OnlineMsg = Convert.ToString(collection["OnlineMsg"]);
            _PartBO.GrossWeight = Convert.ToDecimal(collection["GrossWeight"]);
            _PartBO.Dim_L = Convert.ToInt32(collection["Dim_L"]);
            _PartBO.Dim_W = Convert.ToInt32(collection["Dim_W"]);
            _PartBO.Dim_H = Convert.ToInt32(collection["Dim_H"]);
            _PartBO.PartDetailDescription = Convert.ToString(collection["PartDetailDescription"]);
            _PartBO.PartDescription = Convert.ToString(collection["PartDescription"]);

            _PartBO.SubTypeID = Convert.ToInt32(collection["ddlSubType"]);
            //_PartBO.ddlPartTypeID
            _PartBO.PartNo = Convert.ToString(collection["PartNo"]);

            StringBuilder ViewDataErrorLog = new StringBuilder();



            //_ConditionPriceTrans = new ConditionPriceTrans();
            //_viewConditionPriceTrans = new List<ConditionPriceTrans>();


             
            try
            {

                System.Web.HttpContext.Current.Session["UserID"] = 14;
                _PartBO.PartID = PartBL.CreatePart(_PartBO);
                if (_PartBO.PartID > 0)
                {
                    StringBuilder _ViewDataErrorLog = new StringBuilder();
                    CommonUtil _CommonUtil = new CommonUtil();
                   
                    //var viewConditionPriceTrans = new List<ConditionPriceTrans>();                   
                    //var ConditionPriceDataKeys = collection.AllKeys.Where(k => k.StartsWith("ConditionPriceTransData")).ToDictionary(k => k, k => collection[k]).ToList();
                    //viewConditionPriceTrans = _CommonUtil.GetObjectsFromGridFormCollection<ConditionPriceTrans>("ConditionPriceTransData", ConditionPriceDataKeys, _ViewDataErrorLog);
                    //PartBL.AddConditonPriceTrans(_PartBO.PartID, viewConditionPriceTrans);

                    //var viewRelatedPartTrans = new List<RelatedPartTrans>();
                    //var RelatedPartTransDataKeys = collection.AllKeys.Where(k => k.StartsWith("RelatedPartTransData")).ToDictionary(k => k, k => collection[k]).ToList();
                    //viewRelatedPartTrans = _CommonUtil.GetObjectsFromGridFormCollection<RelatedPartTrans>("RelatedPartTransData", RelatedPartTransDataKeys, _ViewDataErrorLog);
                    //PartBL.AddRelatedPartTrans(_PartBO.PartID, viewRelatedPartTrans);

                    //var viewLogistickTrans = new List<LogistickTrans>();
                    //var LogistickTransDataKeys = collection.AllKeys.Where(k => k.StartsWith("LogistickTransData")).ToDictionary(k => k, k => collection[k]).ToList();
                    //viewLogistickTrans = _CommonUtil.GetObjectsFromGridFormCollection<LogistickTrans>("LogistickTransData", LogistickTransDataKeys, _ViewDataErrorLog);
                    //PartBL.AddLogistickTrans(_PartBO.PartID, viewLogistickTrans);


                    //var viewCompabilityTrans = new List<CompatibilityTrans>();
                    //var CompabilityTransDataKeys = collection.AllKeys.Where(k => k.StartsWith("CompabilityTransData")).ToDictionary(k => k, k => collection[k]).ToList();
                    //viewCompabilityTrans = _CommonUtil.GetObjectsFromGridFormCollection<CompatibilityTrans>("CompabilityTransData", CompabilityTransDataKeys, _ViewDataErrorLog);
                    //PartBL.AddCompatibilityTrans(_PartBO.PartID, viewCompabilityTrans);

                    //var viewSupplierTrans = new List<SupplierTrans>();
                    //var SupplierTransDataKeys = collection.AllKeys.Where(k => k.StartsWith("SupplierTransData")).ToDictionary(k => k, k => collection[k]).ToList();
                    //viewSupplierTrans = _CommonUtil.GetObjectsFromGridFormCollection<SupplierTrans>("SupplierTransData", SupplierTransDataKeys, _ViewDataErrorLog);
                    //PartBL.AddSupplierTrans(_PartBO.PartID, viewSupplierTrans);
                 
                    ViewBag.Message = "Data Save Sucessfully !";

                    return View("ViewPart");
                }


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
            _PartTypeBO = _PartTypeBL.GetAllPartType();
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