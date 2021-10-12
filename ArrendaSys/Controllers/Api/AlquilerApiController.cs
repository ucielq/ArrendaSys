﻿using ArrendaSys.Controllers.Acceso;
using ArrendaSysServicios;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ArrendaSys.Controllers.Api
{
    [SessionUtility]

    public class AlquilerApiController : ApiController
    {

        [System.Web.Http.Route("Api/Alquiler/CrearAlquiler")]
        [System.Web.Http.ActionName("CrearAlquiler")]
        [System.Web.Http.HttpPost]
       

        public int Alquiler(AlquileresViewModel alquiler)
        {
            ServicioAlquiler serv = new ServicioAlquiler();
            return serv.AgregarAlquiler(alquiler);
        }


        [System.Web.Http.Route("Api/Alquiler/ListarAlquileres")]
        [System.Web.Http.ActionName("ListarAlquileres")]
        [System.Web.Http.HttpGet]
        public object ListarAlquileres()
        {
            ServicioAlquiler servicio = new ServicioAlquiler();
            var lista = servicio.ListarAlquileres();
            return lista;
        }

        [System.Web.Http.Route("Api/Alquiler/EliminarAlquiler")]
        [System.Web.Http.ActionName("EliminarAlquiler")]
        [System.Web.Http.HttpPut]
        public void EliminarAlquiler(int idAlquiler)
        {
            ServicioAlquiler servicio = new ServicioAlquiler();
            servicio.EliminarAlquiler(idAlquiler);


        }



    }
}
