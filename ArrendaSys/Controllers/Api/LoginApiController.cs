﻿using ArrendaSysModelos;
using ArrendaSysUtilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ArrendaSys.Controllers.Api
{
    public class LoginApiController : ApiController
    {
        [System.Web.Http.Route("Api/Login/ValidarDatos")]
        [System.Web.Http.ActionName("ValidarDatos")]
        [System.Web.Http.HttpGet]
        public int ValidarDatos(string mailUsuario,string password)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var user = db.Cuenta.Where(x => x.emailCuenta == mailUsuario && x.fechaBajaCuenta==null).FirstOrDefault();
                if (user == null)
                {
                    return 0;
                }
                else
                {
                    if (user.contrasenaCuenta != password)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
            }
        }
        [System.Web.Http.Route("Api/Login/EnviarMail")]
        [System.Web.Http.ActionName("EnviarMail")]
        [System.Web.Http.HttpGet]
        public string EnviarMail()
        {
            ArrendaSysUtilidades.EnvioMail envioMail = new EnvioMail();
            return envioMail.EnviarMailGenerico();
        }
        
    }
}