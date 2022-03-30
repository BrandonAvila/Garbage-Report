using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageReport.Domain.DTOS.Requests
{
    public class EventoCreateRequest
    {
        public string NombredelEvento { get; set; }
        public string DescripciondelEvento { get; set; }
        public string ConsideracionesEspeciales { get; set; }
        public string FechadelEvento { get; set; }
        public string NdpersonasRequeridas { get; set; }
    }
}