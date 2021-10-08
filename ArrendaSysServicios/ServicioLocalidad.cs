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
        public List<LocalidadViewModel> ObtenerLocalidad(int idDepto)
        {
            List<LocalidadViewModel> listaLocalidad;
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                listaLocalidad = (from c in db.Localidad where c.idDepartamento == idDepto

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
