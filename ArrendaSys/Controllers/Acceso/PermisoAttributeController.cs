using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArrendaSysServicios;
using System.Web.Routing;

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
                                       where a.codigo.Equals(codigo)
                                       select new URLViewModel {
                                            idUrl=a.idURL
                                       }).FirstOrDefault();

                var usuario = HttpContext.Current.Session["usuarioLogeado"];
                if(usuario!=null && accesoPorCodigo != null)
                {
                    //Aca revisar el acceso por login y cargo las variables de session del tipo de permiso
                    if (!ServicioCuenta.TienePermisoPorLogin(accesoPorCodigo.idUrl, usuario.ToString()))
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Login",
                            action = "ModuloDenegado"
                        }));
                    }
                    else
                    {
                        //Cargo los permisos en cada vista
                        var rol = ServicioCuenta.ObtenerTiposPermisos(accesoPorCodigo.idUrl, usuario.ToString());
                        HttpContext.Current.Session["tienePermisoEdicion"] = false;
                        HttpContext.Current.Session["tienePermisoEliminacion"] = false;
                        HttpContext.Current.Session["tienePermisoLectura"] = false;
                        if (rol != null)
                        {
                            HttpContext.Current.Session["tienePermisoEdicion"] = rol.tienePermisoEdicion;
                            HttpContext.Current.Session["tienePermisoEliminacion"] = rol.tienePermisoEliminacion;
                            HttpContext.Current.Session["tienePermisoLectura"] = rol.tienePermisoLectura;
                        }
                    }
                    
                    
                }
                else  if (accesoPorCodigo == null)
                { 
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new
                    {
                        controller = "Login",
                        action = "ModuloDenegado"
                    }));
                }
            }
        }
    }
}