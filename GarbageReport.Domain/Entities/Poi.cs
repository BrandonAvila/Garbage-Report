﻿using System;
using System.Collections.Generic;

#nullable disable

namespace GarbageReport.Domain.Entities
{
    public partial class Poi
    {
        public int IdPois { get; set; }
        public string Nombre { get; set; }
        public string Caracteristicas { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
    }
}
