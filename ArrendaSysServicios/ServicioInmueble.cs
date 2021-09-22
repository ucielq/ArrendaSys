using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios
{
    public class ServicioInmueble : IDisposable
    {
        public InmuebleViewModel AgregarInmueble(InmuebleViewModel inmueble)
        {
            ArrendasysEntities db = new ArrendasysEntities();

            Inmueble inmueble1 = new Inmueble
            {
                cantAmbientes = inmueble.cantAmbientes,
                cantBanos= inmueble.cantBanos,
                cantHabitaciones= inmueble.cantHabitaciones,
                cochera= inmueble.cochera,
                descripcionInmueble= inmueble.descripcionInmueble,
                incluyeExpensas= inmueble.incluyeExpensas,
                mtsCuadrados= inmueble.mtsCuadrados,
                mtsCuadradosInt= inmueble.mtsCuadradosInt,
                permiteMascota= inmueble.permiteMascota,
                idArrendador= inmueble.idArrendador,
                tipoArrendador= inmueble.tipoArrendador,
                idDireccion= inmueble.idDireccion
            };
            db.Inmueble.Add(inmueble1);

            db.SaveChanges();
            var ultimo = db.Inmueble.OrderByDescending(x => x.idInmueble).FirstOrDefault();
            inmueble.idInmueble = ultimo.idInmueble;
            return inmueble;
            
        }
        public int GuardarArchivoInmueble(List<ArchivoVM> lista)
        {
            try
            {
                ArrendasysEntities db = new ArrendasysEntities();
                foreach(var archivo in lista)
                {
                    MultimediaInmueble multimediaInmueble = new MultimediaInmueble()
                    {
                        urlMultimediaInmueble= archivo.url,
                        idInmueble= archivo.idInmueble
                    };
                    db.MultimediaInmueble.Add(multimediaInmueble);
                    
                }
                db.SaveChanges();
            }
            catch(Exception e)
            {
                return 400;
            }
            return 200;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
