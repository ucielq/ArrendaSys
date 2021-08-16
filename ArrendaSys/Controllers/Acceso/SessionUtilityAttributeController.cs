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
                    //Obtengo el estado del usuario a nivel existe y esta activo
                    /*
                    if(estado == no existe o inactivo){
                        filterContext.Result = new RedirectResult("~/Login/SesionIncorrecta")
                    } 
                    */
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