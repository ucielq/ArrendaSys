﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrendaSysUtilidades
{
    public class ReseniaPDFVM
    {
        public DateTime? fechaResenia { get; set; }
        public string descripcion { get; set; }
        public int? idAlquiler { get; set; }
        public string autorResenia { get; set; }
        public decimal? puntuacionResenia { get; set; }
        public int? idResenia { get; set; }
        public int? tipoArrendador { get; set; }
        public int? idArrendador { get; set; }
        public string nombre { get; set; }
    }
    public class ItemReseniaPDFVM
    {

    }
}
