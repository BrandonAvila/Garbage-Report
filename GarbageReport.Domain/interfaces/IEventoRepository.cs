using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarbageReport.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GarbageReport.Domain.interfaces
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> TodosLosDatos();
        Task<int> create (Evento evento);
        Task<Evento> PorID(int id);
        Task<bool> Update(int id, Evento evento);
        void EliminarEvento(int id);
    }
}