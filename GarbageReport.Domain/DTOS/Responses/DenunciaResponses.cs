using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageReport.Domain.DTOS.Responses
{
    public class DenunciaResponses
    {
        public int IdDenuncia {get; set;}
        public string InformacionDen {get; set;}
        public string LugarDen {get; set;}
        public string DescripciondeSituacion {get; set;}
        public string FotografiadelLugar {get; set;}
    }
}