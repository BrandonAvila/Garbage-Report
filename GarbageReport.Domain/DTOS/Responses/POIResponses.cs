using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageReport.Domain.DTOS.Responses
{
    public class POIResponses
    {
        public int IdPois {get; set;}
        public string Informacion_POI {get; set;}
        public string Lugar_y_Fecha {get; set;}
        public string Hora {get; set;}
        public string Caracteristicas {get; set;}
    }
}