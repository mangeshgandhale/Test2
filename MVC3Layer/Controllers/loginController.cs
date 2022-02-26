using BusinessLogic;
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3Layer.Controllers
{
    public class loginController : Controller
    {
        UserBL objBs = new UserBL();

        // GET: login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index(UserBO _UserBO)
        {
            UserBO o = new UserBO();
            o = _UserBO;

          //  this.objBs.Insert(o);


            return RedirectToAction("PartAdd", "Part");
        }
    }
}