using ArrendaSysServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers.Acceso
{
    public class SessionUtilityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            var current = HttpContext.Current;
            var user = HttpContext.Current.Session["usuarioLogeado"];
            if (user!=null)
            {
                try
                {
                    var emailUsuario = user.ToString();
                    ServicioCuenta usuario = new ServicioCuenta();
                    var estadoLogin = usuario.ObtenerUsuarioLogueado(emailUsuario);
                    //Obtengo el estado del usuario a nivel existe y esta activo

                    if (estadoLogin == 0 || estadoLogin==-1 ){
                        filterContext.Result = new RedirectResult("~/Login/Login");
                    }

                }
                catch
                {
                    filterContext.Result = new RedirectResult("~/Login/Login");
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Login/Login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}