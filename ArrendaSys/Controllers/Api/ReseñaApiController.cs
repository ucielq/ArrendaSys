using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers.Api
{
    public class ReseñaApiController : Controller
    {
        // GET: ReseñaApi
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReseñaApi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReseñaApi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReseñaApi/Create
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

        // GET: ReseñaApi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReseñaApi/Edit/5
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

        // GET: ReseñaApi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReseñaApi/Delete/5
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
