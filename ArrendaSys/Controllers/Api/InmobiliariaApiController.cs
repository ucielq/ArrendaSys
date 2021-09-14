﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArrendaSysServicios;
using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System.Web.Http;

namespace ArrendaSys.Controllers.Api
{
    public class InmobiliariaApiController : ApiController
    {
        [System.Web.Http.Route("Api/Inmobiliaria/CrearInmobiliaria")]
        [System.Web.Http.ActionName("CrearInmobiliaria")]
        [System.Web.Http.HttpPost]
        public int CrearInmobiliaria(InmobiliariaViewModel inmobiliaria)
        {
            ServicioInmobiliaria serv = new ServicioInmobiliaria();
            return serv.crearInmobiliaria(inmobiliaria);
        }

    }
}
