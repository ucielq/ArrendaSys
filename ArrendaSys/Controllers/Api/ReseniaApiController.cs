﻿using ArrendaSys.Controllers.Acceso;
using ArrendaSysServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ArrendaSysServicios.Modelos;
namespace ArrendaSys.Controllers.Api
{
    [SessionUtility]

    public class ReseniaApiController : ApiController
    {

        [System.Web.Http.Route("Api/Resenia/CrearReseniaArrendador")]
        [System.Web.Http.ActionName("CrearReseniaArrendador")]
        [System.Web.Http.HttpPost]
        public int ReseniaArrendador(ReseniaViewModel resenia)
        {
            ServicioResenia serv = new ServicioResenia();
            return serv.AgregarReseniaArrendador(resenia);
        }

        [System.Web.Http.Route("Api/Resenia/CrearReseniaArrendatario")]
        [System.Web.Http.ActionName("CrearReseniaArrendatario")]
        [System.Web.Http.HttpPost]
        public int ReseniaArrendatario(ReseniaViewModel resenia)
        {
            ServicioResenia serv = new ServicioResenia();
            return serv.AgregarReseniaArrendatario(resenia);
        }

        [System.Web.Http.Route("Api/Resenia/CrearReseniaInmueble")]
        [System.Web.Http.ActionName("CrearReseniaInmueble")]
        [System.Web.Http.HttpPost]
        public int ReseniaInmueble(ReseniaViewModel resenia)
        {
            ServicioResenia serv = new ServicioResenia();
            return serv.AgregarReseniaInmueble(resenia);
        }
        /*
       [System.Web.Http.Route("Api/Reseña/ListarItems")]
       [System.Web.Http.ActionName("ListarItems")]
       [System.Web.Http.HttpGet]
       public object ListarItems(int idAoAr)
       {
           ServicioReseña servicio = new ServicioReseña();
           var lista = servicio.ListarAlquileres(idAoAr);
           return lista;
       }
       */
        /*// GET: ReseñaApi
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
        */
    }
}