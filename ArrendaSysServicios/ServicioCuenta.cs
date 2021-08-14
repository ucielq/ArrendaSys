using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Configuration;
using ArrendaSysModelos;
using ArrendaSysServicios.Modelos;

namespace ArrendaSysServicios
{
    public class ServicioCuenta : IDisposable
    {
        private ArrendasysEntities db = new ArrendasysEntities();

        public CuentaViewModel hola()
        {
            CuentaViewModel cuenta = new CuentaViewModel();
            var c = db.Cuenta.FirstOrDefault();            
            cuenta.email = c.emailCuenta;
            return cuenta;
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
