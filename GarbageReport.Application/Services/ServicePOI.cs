using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarbageReport.Infraestructure.Repositories;
using GarbageReport.Domain.Entities;
using GarbageReport.Domain.interfaces;

namespace GarbageReport.Application.Services
{
    public class ServicePOI : IPOISService
    {
        public bool ValidatedPOI (Poi poi)
        {
            if(string.IsNullOrEmpty(poi.Nombre))
                return false;

            if(string.IsNullOrEmpty(poi.Descripcion))
                return false;

            if(string.IsNullOrEmpty(poi.Ubicacion))
                return false;

            if(string.IsNullOrEmpty(poi.Fecha))
                return false;

            if(string.IsNullOrEmpty(poi.Hora))
                return false;

            if(string.IsNullOrEmpty(poi.Caracteristicas))
                return false;

            return true;
        }

        public bool ValidatedUpdatePOI (Poi poi)
        {
            if(poi.IdPois <= 0)
                return false;
                
            if(string.IsNullOrEmpty(poi.Nombre))
                return false;

            if(string.IsNullOrEmpty(poi.Descripcion))
                return false;

            if(string.IsNullOrEmpty(poi.Ubicacion))
                return false;

            if(string.IsNullOrEmpty(poi.Fecha))
                return false;

            if(string.IsNullOrEmpty(poi.Hora))
                return false;

            if(string.IsNullOrEmpty(poi.Caracteristicas))
                return false;

            return true;
        }
    }
}