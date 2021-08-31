using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios
{
    public class ServicioArrendatario : IDisposable
    {
        public int crearArrendatario(ArrendatarioViewModel arrendatario)
        {
            using (ArrendasysEntities db = new ArrendasysEntities())
            {
                var cuenta = db.Cuenta.Where(x => x.idCuenta == arrendatario.idCuenta).FirstOrDefault();
                cuenta.idRol = 2;
                Arrendatario arrendatario1 = new Arrendatario
                {
                    nombreArrendatario = arrendatario.nombreArrendatario,
                    apellidoArrendatario = arrendatario.apellidoArrendatario,
                    fechaNacimArrendatario = arrendatario.fechaNacimiento,
                    numeroDocumentoArr = arrendatario.nroDocumento,
                    telefonoArrendatario = arrendatario.nroTelefono,
                    idCuenta= arrendatario.idCuenta
                };
                db.Arrendatario.Add(arrendatario1);
                db.SaveChanges();
                return 0;
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
