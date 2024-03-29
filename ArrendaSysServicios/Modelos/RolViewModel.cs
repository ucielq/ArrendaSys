﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class RolViewModel
    {

        public int? idRol { get; set; }
        public string nombreRol { get; set; }
        public bool? tienePermisoLectura { get; set; }
        public bool? tienePermisoEliminacion { get; set; }
        public bool? tienePermisoEdicion { get; set; }
        public int codigoRetorno { get; set; }
        public bool activo { get; set; }
        public int? tipoRol { get; set; }
        public List<URLViewModel> menu { get; set; }
        public string descripcionRol { get; set; }
        public DateTime? fechaAltaRol { get; set; }
        public DateTime? fechaBajaRol { get; set; }

   

    }
}
