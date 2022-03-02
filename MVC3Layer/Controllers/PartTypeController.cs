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
    public class PartTypeController : Controller
    {
        

        public ActionResult Index()
        {
            PartTypeBO cViewData;

            PartTypeBL configOps = new PartTypeBL();

           // try
           // {
                cViewData = new PartTypeBO();
                cViewData = configOps.PopulateViewData();

                return View(cViewData);
           // }
           // catch (Exception ex)
           // {
               // return Json(Constants.vbNull);
           // }
            //finally
            //{
            //  //  configOps.Dispose();
            //}
        }

        public ActionResult delete()
        {
            return View();
        }
            public ActionResult Create(List<PartTypeBO> newPartTypes)
        {
            PartTypeBL partTypeBL = new PartTypeBL();

            try
            {
                partTypeBL.CreatePartTypes(newPartTypes);
                return Json(partTypeBL);
            }
            catch (Exception ex)
            {
                return Json(partTypeBL);
            }
            finally
            {
             //   partTypeBL.Dispose();
            }
        }
        public ActionResult validatePartTypeDesc(int cPartTypeID, string cPartTypeDesc)
        {
            string isDuplicate;
            PartTypeBL configOps = new PartTypeBL();
            try
            {
                isDuplicate = configOps.ValidatePartTypeDesc(cPartTypeID, cPartTypeDesc);
                return Json(isDuplicate);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
            finally
            {
            //    configOps.Dispose();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveView(FormCollection collection)
        {
            PartTypeBO _viewPartTypeBO;
            PartTypeBO _PartTypeBO;
            List<PartTypeBO> viewPartTypes;
            
            int li;
            int openBracketPosition, closeBracketPosition, indexLength;
            int itemIndex, collItemIndex;
            StringBuilder ViewDataErrorLog = new StringBuilder();

            try
            {
                _viewPartTypeBO = new PartTypeBO();
                //if (string.IsNullOrEmpty(collection("ApplicationNo")) == false)
                //    viewTestView.ApplicationNo = collection("ApplicationNo").ToString;
                //else
                //    ViewDataErrorLog.AppendLine("Invalid ApplicationNo");
                _viewPartTypeBO.PartTypeID =Convert.ToInt32(collection["PartTypeID"]);

                li = 0;
                itemIndex = 0;

                _PartTypeBO = new PartTypeBO();
                viewPartTypes = new List<PartTypeBO>();

                for (li = 0; li <= collection.Count - 1; li++)
                {
                    if (collection.GetKey(li).Contains("PartTypeGridData") == true)
                    {
                        openBracketPosition = collection.GetKey(li).IndexOf("(");
                        closeBracketPosition = collection.GetKey(li).IndexOf(")");
                        indexLength = closeBracketPosition - openBracketPosition - 1;

                        collItemIndex = Convert.ToInt32(collection.GetKey(li).Substring((openBracketPosition + 1), indexLength));
                        if (collItemIndex == itemIndex)
                        {
                            if (collection.GetKey(li) == "PartTypeGridData(" + collItemIndex + ").PartTypeID")
                            {
                                string PartTypeIDIndex = "PartTypeGridData(" + collItemIndex + ").PartTypeID";
                                if (string.IsNullOrEmpty(collection[PartTypeIDIndex].ToString()) == false)
                                    _PartTypeBO.PartTypeID =Convert.ToInt32( collection["PartTypeGridData(" + collItemIndex + ").PartTypeID"].ToString());
                                else
                                {
                                    _PartTypeBO.PartTypeID = -1;
                                    ViewDataErrorLog.AppendLine("PartTypeGridData: Invalid PartTypeID");
                                }
                                continue;
                            }

                            if (collection.GetKey(li) == "PartTypeGridData(" + collItemIndex + ").PartTypeDescription")
                            {
                                if (string.IsNullOrEmpty(collection["PartTypeGridData(" + collItemIndex + ").PartTypeDescription"].ToString()) == false)
                                    _PartTypeBO.PartTypeDescription = collection["PartTypeGridData(" + collItemIndex + ").PartTypeDescription"].ToString();
                                else
                                {
                                    _PartTypeBO.PartTypeDescription = "";
                                    ViewDataErrorLog.AppendLine("PartTypeGridData: Invalid PartTypeDescription");
                                }
                                continue;
                            }

                            if (collection.GetKey(li) == "PartTypeGridData(" + collItemIndex + ").Active")
                            {
                                if (string.IsNullOrEmpty(collection["PartTypeGridData(" + collItemIndex + ").Active"].ToString()) == false)
                                {
                                    if (collection["PartTypeGridData(" + collItemIndex + ").Active"].ToString() == "true")
                                        _PartTypeBO.Active = true;
                                    else
                                        _PartTypeBO.Active = false;
                                }
                                else
                                    ViewDataErrorLog.AppendLine("PartTypeGridData: Invalid Active");
                                viewPartTypes.Add(_PartTypeBO);
                                continue;
                            }
                        }
                        else
                        {
                          //  viewPartType = new PartTypeBO();
                            itemIndex = itemIndex + 1;

                            if (collection.GetKey(li) == "PartTypeGridData(" + collItemIndex + ").PartTypeID")
                            {
                                if (string.IsNullOrEmpty(collection["PartTypeGridData(" + collItemIndex + ").PartTypeID"].ToString()) == false)
                                    _PartTypeBO.PartTypeID =Convert.ToInt32( collection["PartTypeGridData(" + collItemIndex + ").PartTypeID"].ToString());
                                else
                                {
                                    _PartTypeBO.PartTypeID = -1;
                                    ViewDataErrorLog.AppendLine("PartTypeGridData: Invalid PartTypeID");
                                }
                                continue;
                            }
                        }
                    }
                }

                _viewPartTypeBO.PartTypeGridData = new List<PartTypeBO>();
                _viewPartTypeBO.PartTypeGridData = viewPartTypes;
            }

            catch (Exception ex)
            {
            }

            return View();
        }

    }
}