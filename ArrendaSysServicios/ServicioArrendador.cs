using ArrendaSysModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios
{
    public class ServicioArrendador : IDisposable
    {

        private ArrendasysEntities db = new ArrendasysEntities();

        public int AltaArrendador(int id, string nombre, string apellido, int doc, int telefono)
        {
            return 0;
        }















        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
