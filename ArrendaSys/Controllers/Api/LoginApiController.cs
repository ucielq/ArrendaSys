using ArrendaSysModelos;
using ArrendaSysServicios;
using ArrendaSysServicios.Modelos;
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
        public CuentaViewModel ValidarDatos(string mailUsuario, string password)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var user = db.Cuenta.Where(x => x.emailCuenta == mailUsuario && x.fechaBajaCuenta == null).FirstOrDefault();
                var ePass = Encrypt.GetSHA256(password);
                CuentaViewModel model = new CuentaViewModel();

                if (user == null)
                {
                    model.idCuenta = 0;
                    return model;
                }
                else
                {
                    if (user.fechaAltaCuenta == null && user.contrasenaCuenta==ePass)
                    {
                        model.idCuenta = 3;
                        model.codigoConfirmacion = user.idCuenta;
                        return model;

                    }
                    else
                    {
                        if (user.contrasenaCuenta != ePass)
                        {
                            model.idCuenta = 1;
                            return model;
                        }
                        else
                        {
                            model.idCuenta = 2;
                            return model;
                        }
                    }
                }
            }
        }


    }
}