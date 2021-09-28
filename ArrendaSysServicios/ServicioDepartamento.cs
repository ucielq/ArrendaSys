using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios
{
    public class ServicioDepartamento
    {
        public object ObtenerDepto()
        {
            List<DepartamentoViewModel> listaDepto;
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                listaDepto = (from c in db.Departamento
                              select new DepartamentoViewModel
                              {
                                  idDepartamento=c.idDepartamento,
                                  nombreDepartamento = c.nombreDepartamento
                                  
                              }).ToList();
            }

            object json = new { data = listaDepto };

            return json;
        }

    }
}
