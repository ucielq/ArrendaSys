﻿using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ArrendaSysServicios;
namespace ArrendaSys.Controllers.Api
{
    public class CuentaApiController : ApiController
    {
        [System.Web.Http.Route("Api/Cuenta/ValidarMail")]
        [System.Web.Http.ActionName("ValidarMail")]
        [System.Web.Http.HttpGet]
        public int ValidarMail(string email)
        {
            using(ArrendaSysModelos.ArrendasysEntities db = new ArrendaSysModelos.ArrendasysEntities())
            {
                var existe = db.Cuenta.Where(x => x.emailCuenta == email).FirstOrDefault();
                if (existe != null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        [System.Web.Http.Route("Api/Cuenta/altaCuenta")]
        [System.Web.Http.ActionName("altaCuenta")]
        [System.Web.Http.HttpGet]
        public int altaCuenta(string email, string password)
        {
            ServicioCuenta servicioCuenta = new ArrendaSysServicios.ServicioCuenta();
            return servicioCuenta.altaCuenta(email, password);
        }

        [System.Web.Http.Route("Api/Cuenta/ObtenerId")]
        [System.Web.Http.ActionName("ObtenerId")]
        [System.Web.Http.HttpGet]
        public int ObtenerId(string email)
        {
            ServicioCuenta servicioCuenta = new ArrendaSysServicios.ServicioCuenta();
            return servicioCuenta.ObtenerUsuarioLogueado(email);
        }
        [System.Web.Http.Route("Api/Cuenta/ObtenerDatosCuenta")]
        [System.Web.Http.ActionName("ObtenerDatosCuenta")]
        [System.Web.Http.HttpGet]
        public CuentaViewModel ObtenerDatosCuenta(int idCuenta)
        {
            ServicioCuenta servicio = new ServicioCuenta();
            CuentaViewModel cuenta = servicio.ObtenerDatosCuenta(idCuenta);
            return cuenta;
        }
    }
}