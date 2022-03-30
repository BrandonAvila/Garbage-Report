using System;
using System.Collections.Generic;

#nullable disable

namespace GarbageReport.Domain.Entities
{
    public partial class Ciudadano
    {
        public int IdCiudadania { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}
