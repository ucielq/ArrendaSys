using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios
{
    public class ServicioPropietario : IDisposable
    {
        public async Task<int> CrearPropietario(PropietarioViewModel propietario)
        {
            ArrendasysEntities db = new ArrendasysEntities();
            var cuenta = db.Cuenta.Where(x => x.idCuenta == propietario.idCuenta).FirstOrDefault();
            var arrenda = db.Arrendatario.Where(x => x.idCuenta == cuenta.idCuenta).FirstOrDefault();
            if (arrenda != null)
            {
                db.Arrendatario.Remove(arrenda);
            }
            var inmo = db.Inmobiliaria.Where(x => x.idCuenta == cuenta.idCuenta).FirstOrDefault();
            if (inmo != null)
            {
                db.Inmobiliaria.Remove(inmo);
            }
            cuenta.idRol = 3;
            cuenta.direccion = propietario.direccion;
            var propietario2 = db.Propietario.Where(x => x.idCuenta == propietario.idCuenta).FirstOrDefault();
            if (propietario2 != null)
            {
                propietario2.nombrePropietario = propietario.nombrePropietario;
                propietario2.apellidoPropietario = propietario.apellidoPropietario;
                propietario2.fechaNacimPropietario = propietario.fechaNacimiento;
                propietario2.numeroDocumentoProp = propietario.numeroDocumentoPropietario;
                propietario2.telefonoPropietario = propietario.telefonoPropietario;
                propietario2.idCuenta = propietario.idCuenta;
                db.SaveChanges();
                return propietario2.idPropietario;
            }
            else
            {
                Propietario propietario1 = new Propietario
                {
                    nombrePropietario = propietario.nombrePropietario,
                    apellidoPropietario = propietario.apellidoPropietario,
                    fechaNacimPropietario = propietario.fechaNacimiento,
                    numeroDocumentoProp = propietario.numeroDocumentoPropietario,
                    telefonoPropietario = propietario.telefonoPropietario,
                    idCuenta = propietario.idCuenta
                };
                db.Propietario.Add(propietario1);
                await db.SaveChangesAsync();
                return propietario1.idPropietario;
            }
        }
        

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
