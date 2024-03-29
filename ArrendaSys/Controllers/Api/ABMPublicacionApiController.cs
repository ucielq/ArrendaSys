﻿using ArrendaSys.Controllers.Acceso;
using ArrendaSysServicios;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ArrendaSys.Controllers.Api
{
    [SessionUtility]
    public class ABMPublicacionApiController : ApiController
    {

        [System.Web.Http.Route("Api/ABMPublicacion/CrearPublicacion")]
        [System.Web.Http.ActionName("CrearPublicacion")]
        [System.Web.Http.HttpPost]


        public void CrearPublicacion(ABMPublicacionViewModel publicacion)
        {
            ServicioABMPublicacion serv = new ServicioABMPublicacion();
           serv.AgregarPublicacion(publicacion);
        }


        [System.Web.Http.Route("Api/ABMPublicacion/ListarPublicaciones")]
        [System.Web.Http.ActionName("ListarPublicaciones")]
        [System.Web.Http.HttpGet]
        public object ListarPublicaciones(int idCuenta, int tipoCuenta)
        {
            ServicioABMPublicacion servicio = new ServicioABMPublicacion();
            var lista = servicio.ListarPublicaciones(idCuenta, tipoCuenta);
            return lista;
        }

        [System.Web.Http.Route("Api/ABMPublicacion/EliminarPublicacion")]
        [System.Web.Http.ActionName("EliminarPublicacion")]
        [System.Web.Http.HttpPost]
        public void EliminarPublicacion(ABMPublicacionViewModel publicacion)
        {
            ServicioABMPublicacion servicio = new ServicioABMPublicacion();
            servicio.EliminarPublicacion(publicacion);


        }
        [System.Web.Http.Route("Api/ABMPublicacion/TraerPublicaciones")]
        [System.Web.Http.ActionName("TraerPublicaciones")]
        [System.Web.Http.HttpGet]
        public List<ABMPublicacionViewModel> TraerPublicaciones(int idDepto, int hab, int banios, int coch, int masc, int exp)
        {
            ServicioABMPublicacion servicio = new ServicioABMPublicacion();
            var lista = servicio.TraerPublicaciones(idDepto, hab, banios, coch, masc,exp);
            return lista;
        }

        [System.Web.Http.Route("Api/ABMPublicacion/EditarPublicacion")]
        [System.Web.Http.ActionName("EditarPublicacion")]
        [System.Web.Http.HttpPost]
        public void EditarPublicacion(ABMPublicacionViewModel publicacion)
        {
            ServicioABMPublicacion serv = new ServicioABMPublicacion();
           serv.EditarPublicacion(publicacion);
        }

        [System.Web.Http.Route("Api/ABMPublicacion/VerPublicacion")]
        [System.Web.Http.ActionName("VerPublicacion")]
        [System.Web.Http.HttpGet]
        public ABMPublicacionViewModel VerPublicacion(int idPublicacion)
        {
            ServicioABMPublicacion serv = new ServicioABMPublicacion();
            return serv.VerPublicacion(idPublicacion);
        }


    }
}