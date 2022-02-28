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
    public class UserTypeController : Controller
    {
        // GET: UserType
        public ActionResult Index()
        {
            return View();
        }
    }
}