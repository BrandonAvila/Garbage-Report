//cSpell:disable

using System;
using System.Collections.Generic;
using System.Linq;
using GarbageReport.Infraestructure.Data;
using GarbageReport.Domain.Entities;

namespace GarbageReport.Infraestructure.Repositories
{
    public class EventoSqlRepository
    {
        private readonly GarbageReportContext _context;

        public EventoSqlRepository()
        {
            _context = new GarbageReportContext();
        }

        public IEnumerable<Evento> TodosLosDatos()
        {
            var evento = _context.Eventos.Select(et => et);
            return evento;
        }
    }
}