using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageReport.Domain.DTOS.Requests
{
    public class DenunciaCreateRequest
    {
        public string FechadeDenuncia { get; set; }
        public string MotivodeDenuncia { get; set; }
        public string DescripciondeSituacion { get; set; }
        public string UbicaciondeDenuncia { get; set; }
        public string ColoniadelEvento { get; set; }
        public string FotografiadelLugar { get; set; }
    }
}