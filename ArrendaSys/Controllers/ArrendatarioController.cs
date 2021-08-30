using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArrendaSys.Controllers
{
    public class ArrendatarioController : Controller
    {
        // GET: Arrendatario
        public ActionResult CrearArrendatario()
        {
            return View();
        }
        public int CrearArr(ArrendatarioViewModel arrendatario)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                try
                {
                    Arrendatario a = new Arrendatario
                    {

                        nombreArrendatario = arrendatario.nombreArrendatario,
                        apellidoArrendatario = arrendatario.apellidoArrendatario,
                        numeroDocumentoArr = arrendatario.numeroDocumentoArr,
                        tipoDocumentoArr = arrendatario.tipoDocumentoArr,
                        telefonoArrendatario = arrendatario.telefonoArrendatario
                       // fechaNacimArrendatario = arrendatario.fechaNacimArrendatario
                    };
                    db.Arrendatario.Add(a);
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
