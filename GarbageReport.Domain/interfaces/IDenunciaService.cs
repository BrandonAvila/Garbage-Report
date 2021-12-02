using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarbageReport.Domain.Entities;

namespace GarbageReport.Domain.interfaces
{
    public interface IDenunciaService
    {
        bool Validated (Denuncia denuncia);
        bool ValidatedUpdate(Denuncia denuncia);
    }
}