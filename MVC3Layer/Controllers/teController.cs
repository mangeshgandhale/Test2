using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC3Layer.Controllers
{
    public class teController : Controller
    {
        // GET: te
        public ActionResult Index()
        {
            return View();
        }

        // GET: te/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: te/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: te/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: te/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: te/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: te/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: te/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
