using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers
{
    public class PropietarioController : Controller
    {

        public ActionResult CrearArrendador()
        {
            return View();
        }
        public ActionResult PerfilArrendador()
        {




            return View();
        }

        public int CrearPropietario(PropietarioViewModel propietario)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                try
                {
                    Propietario p = new Propietario
                    {
                        nombrePropietario = propietario.nombrePropietario,
                        apellidoPropietario = propietario.apellidoPropietario,
                        numeroDocumentoProp = propietario.numeroDocumentoPropietario,
                        tipoDocumentoProp = propietario.tipoDocumentoProp,
                        telefonoPropietario = propietario.telefonoPropietario
                    };
                    db.Propietario.Add(p);
                    db.SaveChanges();
                    return 200;
                }
                catch (Exception e)
                {
                    return 404;
                }
            }

        }


    }
}
