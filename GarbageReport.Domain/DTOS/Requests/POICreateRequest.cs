using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageReport.Domain.DTOS.Requests
{
    public class POICreateRequest
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Caracteristicas { get; set; }
    }
}