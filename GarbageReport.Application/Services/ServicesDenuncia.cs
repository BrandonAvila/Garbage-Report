using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarbageReport.Infraestructure.Repositories;
using GarbageReport.Domain.Entities;
using GarbageReport.Domain.interfaces;

namespace GarbageReport.Application.Services
{
    public class ServicesDenuncia : IDenunciaService
    {
        // public bool Validated (Denuncia denuncia)
        // {
        //     if(string.IsNullOrEmpty(denuncia.FechadeDenuncia))
        //         return false;

        //     if(string.IsNullOrEmpty(denuncia.MotivodeDenuncia))
        //         return false;

        //     if(string.IsNullOrEmpty(denuncia.DescripciondeSituacion))
        //         return false;

        //     if(string.IsNullOrEmpty(denuncia.UbicaciondeDenuncia))
        //         return false;

        //     if(string.IsNullOrEmpty(denuncia.ColoniadelEvento))
        //         return false;

        //     if(string.IsNullOrEmpty(denuncia.FotografiadelLugar))
        //         return false;

        //     return true;
        // }

        public bool ValidatedUpdate (Denuncia denuncia)
        {
            if(denuncia.IdDenuncia <= 0)
                return false;
                
            if(string.IsNullOrEmpty(denuncia.FechadeDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncia.MotivodeDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncia.UbicaciondeDenuncia))
                return false;

            if(string.IsNullOrEmpty(denuncia.FotografiadelLugar))
                return false;

            return true;
        }
    }
}