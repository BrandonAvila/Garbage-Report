using System;
using System.Collections.Generic;

#nullable disable

namespace GarbageReport.Domain.Entities
{
    public partial class Denuncia
    {
        public int IdDenuncia { get; set; }
        public string TitulodeDenuncia { get; set; }
        public string MotivodeDenuncia { get; set; }
        public string FechadeDenuncia { get; set; }
        public string FotografiadelLugar { get; set; }
        public string UbicaciondeDenuncia { get; set; }
    }
}
