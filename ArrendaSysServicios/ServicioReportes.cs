using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrendaSysModelos;
using ArrendaSysUtilidades;
namespace ArrendaSysServicios
{
    public class ServicioReportes
    {
        public List<ReseniaPDFVM> prueba()
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                
                List<ReseniaPDFVM> lista = new List<ReseniaPDFVM>();
                lista = (from r in db.ReseñaArrendadorArrendatario
                         join a in db.Alquiler on r.idAlquiler equals a.idAlquiler
                         join i in db.Inmueble on a.idInmueble equals i.idInmueble
                         join p in db.Propietario on i.idArrendador equals p.idPropietario
                         where i.tipoArrendador == 3 && i.idArrendador == 11
                         select new ReseniaPDFVM
                         {
                             autorResenia=p.apellidoPropietario + " "+ p.nombrePropietario,
                             fechaResenia = r.fechaAltaReseñaAoAr,
                             descripcion = r.descripcionReseñaAoAr,
                             puntuacionResenia = r.puntuacionReseñaAoAr
                         }).ToList();
                return lista;
            }
        }
    }
}
