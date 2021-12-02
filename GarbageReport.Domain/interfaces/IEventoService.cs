using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarbageReport.Domain.Entities;

namespace GarbageReport.Domain.interfaces
{
    public interface IEventoService
    {
        bool ValidatedEvento(Evento evento);
        bool ValidatedUpdateEvento(Evento evento);
    }
}