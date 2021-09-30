using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios
{
    public class ServicioLocalidad
    {
        public List<LocalidadViewModel> ObtenerLocalidad()
        {
            List<LocalidadViewModel> listaLocalidad;
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                listaLocalidad = (from c in db.Localidad
                                  
                              select new LocalidadViewModel
                              {
                                  idLocalidad = c.idLocalidad,
                                  nombreLocalidad = c.nombreLocalidad

                              }).ToList();
            }
            return listaLocalidad;
        }
    }
}
