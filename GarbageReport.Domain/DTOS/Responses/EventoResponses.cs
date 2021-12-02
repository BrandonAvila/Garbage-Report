using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageReport.Domain.DTOS.Responses
{
    public class EventoResponses
    {
        public int IdEventos {get; set;}
        public string InfoEvento {get; set;}
        public string LugardelEvento {get; set;}
        public string DescripciondelEvento {get; set;}
        public string NdpersonasRequeridas {get; set;}
    }
}