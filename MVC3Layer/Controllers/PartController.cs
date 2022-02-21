using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3Layer.Controllers
{
    public class PartController : Controller
    {
        // GET: Part
        public ActionResult PartAdd()
        {
            return View(new BusinessObject.PartBO()
            {
                PartNo = "John",
              //  PartDescription = "Doe"
              
            });
        }

        [HttpPost]
        public ActionResult PartAdd(BusinessObject.PartBO _PartBO)
        {
            if (!ModelState.IsValid)
            {
                return View(_PartBO);
            }
            else
            {
                TempData["View"] = "Overview";
                return View("Success");
            }
        }
    }
}