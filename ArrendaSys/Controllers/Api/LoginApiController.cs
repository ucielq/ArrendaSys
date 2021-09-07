using ArrendaSysModelos;
using ArrendaSysServicios;
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
                var user = db.Cuenta.Where(x => x.emailCuenta == mailUsuario && x.fechaBajaCuenta == null && x.fechaAltaCuenta!=null).FirstOrDefault();
                var ePass = Encrypt.GetSHA256(password);
                if (user == null)
                {
                    return 0;
                }
                else
                {
                    if (user.contrasenaCuenta != ePass)
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
        
        
    }
}