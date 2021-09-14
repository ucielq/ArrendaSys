﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysServicios.Modelos
{
    public class InmobiliariaViewModel
    {
        public DateTime altaInscripcion { get; set; }
        public string altaInscripcionStr { get; set; }
        public string nombreInmobiliaria { get; set; }
        public string telefonoInmobiliariaStr { get; set; }
        public int telefonoInmobiliaria { get; set; }
        public int cuitInmobiliaria { get; set; }
        public int idCuenta { get; set; }
    }
}