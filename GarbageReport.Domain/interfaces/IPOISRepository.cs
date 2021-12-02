using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarbageReport.Domain.Entities;

namespace GarbageReport.Domain.interfaces
{
    public interface IPOISRepository
    {
        Task<IEnumerable<Poi>> TodosLosDatos();
        Task<Poi> PorID(int id);
        Task<int> create(Poi poi);
        Task<bool> Update(int id, Poi poi);
    }
}