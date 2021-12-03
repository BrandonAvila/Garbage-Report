using System;
using System.Collections.Generic;
using System.Linq;
using GarbageReport.Domain.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GarbageReport.Domain.interfaces
{
    public interface IDenunciaRepository
    {
        Task<IEnumerable<Denuncia>> TodosLosDatos();
        
        Task<int> create (Denuncia denuncia);

        //Task<bool> Update(int id, Denuncia denuncia);
        Task<Denuncia> PorID (int id);
    }
}