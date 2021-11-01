//cSpell:disable

using System;
using System.Collections.Generic;
using System.Linq;
using GarbageReport.Infraestructure.Data;
using GarbageReport.Domain.Entities;

namespace GarbageReport.Infraestructure.Repositories
{
    public class POISSqlRepository
    {
        private readonly GarbageReportContext _context;

        public POISSqlRepository()
        {
            _context = new GarbageReportContext();
        }

        public IEnumerable<Poi> TodosLosDatos()
        {
            var encuentro = _context.Pois.Select(g => g);
            return encuentro;
        }

        //retorna a los pois por nombre
        public IEnumerable<Poi> BuscarNombre(string nombre)
        {
            var encuentro = _context.Pois.Where(g => g.Nombre == nombre);
            return encuentro;
        }


        
    }
}