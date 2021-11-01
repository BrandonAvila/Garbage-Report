using System;
using System.Collections.Generic;

#nullable disable

namespace GarbageReport.Domain.Entities
{
    public partial class Evento
    {
        public Evento ()
        {
            
        }
        public int IdEventos { get; set; }
        public string NombredelEvento { get; set; }
        public string DescripciondelEvento { get; set; }
        public DateTime FechadelEvento { get; set; }
        public string UbicaciondelEvento { get; set; }
        public int NdpersonasRequeridas { get; set; }
        public string CaracteristicasdelEvento { get; set; }
        public string Patrocinadores { get; set; }
        public string ConsideracionesEspeciales { get; set; }
    }
}
