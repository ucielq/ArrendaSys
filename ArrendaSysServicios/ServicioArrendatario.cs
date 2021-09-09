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
                var inmo = db.Inmobiliaria.Where(x => x.idCuenta == cuenta.idCuenta).FirstOrDefault();
                if (inmo != null)
                {
                    db.Inmobiliaria.Remove(inmo);
                }
                var prop = db.Propietario.Where(x => x.idCuenta == cuenta.idCuenta).FirstOrDefault();
                if (prop != null)
                {
                    db.Propietario.Remove(prop);
                }
                cuenta.idRol = 2;
                var arrendatario2 = db.Arrendatario.Where(x => x.idCuenta == arrendatario.idCuenta).FirstOrDefault();
                if (arrendatario2!=null)
                {
                    arrendatario2.nombreArrendatario = arrendatario.nombreArrendatario;
                    arrendatario2.apellidoArrendatario = arrendatario.apellidoArrendatario;
                    arrendatario2.fechaNacimArrendatario = arrendatario.fechaNacimiento;
                    arrendatario2.numeroDocumentoArr = arrendatario.nroDocumento;
                    arrendatario2.telefonoArrendatario = arrendatario.nroTelefono;
                    arrendatario2.idCuenta = arrendatario.idCuenta;
                }
                else { 
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
                }
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
