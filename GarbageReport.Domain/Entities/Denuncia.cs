using System;
using System.Collections.Generic;

#nullable disable

namespace GarbageReport.Domain.Entities
{
    public partial class Denuncia
    {
        public Denuncia ()
        {
            
        }
        public int IdDenuncia { get; set; }
        public DateTime FechadeDenuncia { get; set; }
        public string MotivodeDenuncia { get; set; }
        public string DescripciondeSituacion { get; set; }
        public string UbicaciondeDenuncia { get; set; }
        public string ColoniadelEvento { get; set; }
        public string FotografiadelLugar { get; set; }
    }
}
