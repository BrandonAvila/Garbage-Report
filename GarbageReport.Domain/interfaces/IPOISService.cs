using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarbageReport.Domain.Entities;

namespace GarbageReport.Domain.interfaces
{
    public interface IPOISService
    {
        bool ValidatedPOI(Poi poi);
        bool ValidatedUpdatePOI(Poi poi);
    }
}