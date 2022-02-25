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
            CommonMasterBL _CommonMasterBL = new CommonMasterBL();
            ViewBag.lstCompatibilityPart = _PartBL.CompatibilityPart(0);

            _CompatibilityTrans = _PartBL.CompatibilityPart(0);
            ViewBag.lstRelatedPartTrans = _PartBL.RelatedPartTrans(0);
            ViewBag.lstSupplierTrans = _PartBL.SupplierTrans(70);
            ViewBag.lstConditionPriceTrans = _PartBL.ConditionPriceTrans(0);
            ViewBag.lstlogisticksTrans = _PartBL.LogistickTrans(0);
            ViewBag.lstAbbrevation = _CommonMasterBL.GetAllAbbrevation();
            ViewBag.lstSupplier = _CommonMasterBL.GetAllSupplier("");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PartAdd(FormCollection collection)
        //public ActionResult PartAdd(BusinessObject.PartBO _PartBO)
        {


            ConditionPriceTrans _ConditionPriceTrans;
            List<ConditionPriceTrans> _viewConditionPriceTrans;


            PartBL PartBL = new PartBL();
            BusinessObject.PartBO _PartBO = new PartBO();
            int li;
            int openBracketPosition, closeBracketPosition, indexLength;
            int itemIndex, collItemIndex;
            li = 0;
            itemIndex = 0;


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



            _ConditionPriceTrans = new ConditionPriceTrans();
            _viewConditionPriceTrans = new List<ConditionPriceTrans>();


            for (li = 0; li <= collection.Count - 1; li++)
            {
                if (collection.GetKey(li).Contains("ConditionPriceData") == true)
                {
                    openBracketPosition = collection.GetKey(li).IndexOf("(");
                    closeBracketPosition = collection.GetKey(li).IndexOf(")");
                    indexLength = closeBracketPosition - openBracketPosition - 1;

                    collItemIndex = Convert.ToInt32(collection.GetKey(li).Substring((openBracketPosition + 1), indexLength));

                    if (collItemIndex == itemIndex)
                    {

                        if (collection.GetKey(li) == "ConditionPriceData(" + collItemIndex + ").PartConditionPriceID")
                        {
                            string PartConditionPriceID = "ConditionPriceData(" + collItemIndex + ").PartConditionPriceID";

                            if (string.IsNullOrEmpty(collection[PartConditionPriceID].ToString()) == false)
                                _ConditionPriceTrans.PartConditionPriceID = Convert.ToInt32(collection["ConditionPriceData(" + collItemIndex + ").PartConditionPriceID"].ToString());
                            else
                            {
                                _ConditionPriceTrans.PartConditionPriceID = -1;
                                ViewDataErrorLog.AppendLine("ConditionPriceData: Invalid PartConditionPriceID");
                            }
                            continue;
                        }

                        if (collection.GetKey(li) == "ConditionPriceData(" + collItemIndex + ").ConditionID")
                        {
                            string ConditionID = "ConditionPriceData(" + collItemIndex + ").ConditionID";

                            if (string.IsNullOrEmpty(collection[ConditionID].ToString()) == false)
                                _ConditionPriceTrans.ConditionID = Convert.ToInt32(collection["ConditionPriceData(" + collItemIndex + ").ConditionID"].ToString());
                            else
                            {
                                _ConditionPriceTrans.ConditionID = -1;
                                ViewDataErrorLog.AppendLine("ConditionPriceData: Invalid ConditionID");
                            }
                            continue;
                        }

                        if (collection.GetKey(li) == "ConditionPriceData(" + collItemIndex + ").PriceQty")
                        {
                            string PriceQty = "ConditionPriceData(" + collItemIndex + ").PriceQty";

                            if (string.IsNullOrEmpty(collection[PriceQty].ToString()) == false)
                                _ConditionPriceTrans.PriceQty = Convert.ToInt32(collection["ConditionPriceData(" + collItemIndex + ").PriceQty"].ToString());
                            else
                            {
                                _ConditionPriceTrans.PriceQty = -1;
                                ViewDataErrorLog.AppendLine("ConditionPriceData: Invalid Stockable");
                            }


                            _viewConditionPriceTrans.Add(_ConditionPriceTrans);

                            continue;

                        }
                        if (collection.GetKey(li) == "ConditionPriceData(" + collItemIndex + ").Price")
                        {
                            string Price = "ConditionPriceData(" + collItemIndex + ").Price";

                            if (string.IsNullOrEmpty(collection[Price].ToString()) == false)
                                _ConditionPriceTrans.Price = Convert.ToInt32(collection["ConditionPriceData(" + collItemIndex + ").Price"].ToString());
                            else
                            {
                                _ConditionPriceTrans.Price = -1;
                                ViewDataErrorLog.AppendLine("ConditionPriceData: Invalid Stockable");
                            }

                            continue;

                        }

                        collItemIndex = collItemIndex + 1;

                    }
                    else
                    {

                        _ConditionPriceTrans = new ConditionPriceTrans();

                        itemIndex = itemIndex + 1;

                        if (collection.GetKey(li) == "ConditionPriceData(" + collItemIndex + ").PartID")
                        {
                            if (string.IsNullOrEmpty(collection["ConditionPriceData(" + collItemIndex + ").PartID"].ToString()) == false)
                                _ConditionPriceTrans.PartID = Convert.ToInt32(collection["ConditionPriceData(" + collItemIndex + ").PartID"]);
                            else
                            {
                                _ConditionPriceTrans.PartID = -1;
                                ViewDataErrorLog.AppendLine("ConditionPriceData: Invalid PartID");
                            }
                            continue;
                        }
                    }

                }
            }

            // _ConditionPriceTrans
            try
            {
                _PartBO.PartID = PartBL.CreatePart(_PartBO);
                if (_PartBO.PartID > 0)
                {
                    PartBL.AddConditonPriceTrans(_PartBO.PartID, _viewConditionPriceTrans);
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