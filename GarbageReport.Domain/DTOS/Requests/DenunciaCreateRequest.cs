using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageReport.Domain.DTOS.Requests
{
    public class DenunciaCreateRequest
    {
        public string TitulodeDenuncia { get; set; }
        public string MotivodeDenuncia { get; set; }
        public string FechadeDenuncia { get; set; }
        public string FotografiadelLugar { get; set; }
        public string UbicaciondeDenuncia { get; set; }
    }
}