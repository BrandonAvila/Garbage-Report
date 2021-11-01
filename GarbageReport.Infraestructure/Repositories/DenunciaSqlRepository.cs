//cSpell:disable

using System;
using System.Collections.Generic;
using System.Linq;
using GarbageReport.Infraestructure.Data;
using GarbageReport.Domain.Entities;

namespace GarbageReport.Infraestructure.Repositories
{
    public class DenunciaSqlRepository
    {
        private readonly GarbageReportContext _context;

        public DenunciaSqlRepository()
        {
            _context = new GarbageReportContext();
        }

        public IEnumerable<Denuncia> TodosLosDatos()
        {
            var denuncia = _context.Denuncias.Select(dn => dn);
            return denuncia;
        }
    }
}