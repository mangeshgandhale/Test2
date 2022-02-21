using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BusinessObject;
using BusinessLogic;
namespace MVC3Layer.Controllers
{
    public class UserController : Controller
    {
        UserBL objBs = new UserBL();

        // GET: User
        public ActionResult Index()
        {

            //   objBs.GetAll();

            return View();
        }
        public ActionResult In()
        {

            //   objBs.GetAll();

            return View();
        }

        public ActionResult Create(UserBO _UserBO)
        {
            UserBO o = new UserBO();
            o.UserEmail = _UserBO.UserEmail;

            //   this.objBs.Insert(o);
            return View("Index");
        }
       
        public ActionResult Newuser(UserBO _UserBO)
        {
            UserBO o = new UserBO();
            o = _UserBO;

          this.objBs.Insert(o);
            return View("Index");
        }
    }
}