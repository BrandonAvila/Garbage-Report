using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarbageReport.Domain.Entities;
using GarbageReport.Infraestructure.Data;

namespace GarbageReport.Infraestructure.Repositories
{
    public class GarbageReportRepository
    {
        private GarbageReportContext _poi;

        public IEnumerable<Poi> TodosLosDatos ()
        {
            return _poi.Pois;
        }
    }
}