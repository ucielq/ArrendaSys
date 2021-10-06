using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios
{
    public class ServicioDireccion : IDisposable
    {
        public DireccionViewModel AgregarDireccion(DireccionViewModel direccion)
        {
            ArrendasysEntities db = new ArrendasysEntities();
            
         
                Direccion dire = new Direccion
                {
                    nombreCalle = direccion.nombreCalle,
                    numeroCalle = direccion.numeroCalle,
                    nombreBarrio = direccion.nombreBarrio,
                    idManzana = direccion.idManzana,
                    idLote = direccion.idLote,
                    idLocalidad = direccion.idLocalidad
                };
                db.Direccion.Add(dire);

                db.SaveChanges();
                var ultimadireccion = db.Direccion.OrderByDescending(x => x.idDireccion).FirstOrDefault();
                dire.idDireccion = ultimadireccion.idDireccion;
                //int id = ultimadireccion.idDireccion;
                return direccion;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
