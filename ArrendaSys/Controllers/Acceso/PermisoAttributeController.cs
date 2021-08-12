using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers.Acceso
{
    public class PermisoAttribute : ActionFilterAttribute
    {
        public string codigo { get; set; }

        public PermisoAttribute(string cod)
        {
            codigo = cod;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            using (ArrendasysEntities db = new ArrendasysEntities()) { 
                base.OnActionExecuting(filterContext);

                var accesoPorCodigo = (from a in db.URL
                                       where a.idURL.Equals(codigo)
                                       select new URLViewModel {
                                            idUrl=a.idURL
                                       }).FirstOrDefault();

                var usuario = HttpContext.Current.Session["usuarioLogeado"];
                if(usuario!=null && accesoPorCodigo != null)
                {
                    //Aca revisar el acceso por login y cargo las variables de session del tipo de permiso
                    //HttpContext.Current.Session["tienePermisoLectura"]= lo que sea que tenga ...
                }
                else  if (accesoPorCodigo == null)
                { 
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                    {
                        controller = "Login",
                        action = "PermisoDenegado"
                    }));
                }
            }
        }
    }
}