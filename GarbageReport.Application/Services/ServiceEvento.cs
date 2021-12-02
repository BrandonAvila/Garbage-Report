using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarbageReport.Infraestructure.Repositories;
using GarbageReport.Domain.Entities;
using GarbageReport.Domain.interfaces;

namespace GarbageReport.Application.Services
{
    public class ServiceEvento : IEventoService
    {
        public bool ValidatedEvento(Evento evento)
        {
            if(string.IsNullOrEmpty(evento.NombredelEvento))
                return false;

            if(string.IsNullOrEmpty(evento.DescripciondelEvento))
                return false;

            if(string.IsNullOrEmpty(evento.FechadelEvento))
                return false;

            if(string.IsNullOrEmpty(evento.UbicaciondelEvento))
                return false;

            if(string.IsNullOrEmpty(evento.NdpersonasRequeridas))
                return false;

            if(string.IsNullOrEmpty(evento.CaracteristicasdelEvento))
                return false;

            if(string.IsNullOrEmpty(evento.Patrocinadores))
                return false;

            if(string.IsNullOrEmpty(evento.ConsideracionesEspeciales))
                return false;

            return true;
        }

        public bool ValidatedUpdateEvento (Evento evento)
        {
            if(evento.IdEventos <= 0)
                return false;
                
            if(string.IsNullOrEmpty(evento.NombredelEvento))
                return false;

            if(string.IsNullOrEmpty(evento.DescripciondelEvento))
                return false;

            if(string.IsNullOrEmpty(evento.FechadelEvento))
                return false;

            if(string.IsNullOrEmpty(evento.UbicaciondelEvento))
                return false;

            if(string.IsNullOrEmpty(evento.NdpersonasRequeridas))
                return false;

            if(string.IsNullOrEmpty(evento.CaracteristicasdelEvento))
                return false;

            if(string.IsNullOrEmpty(evento.Patrocinadores))
                return false;

            if(string.IsNullOrEmpty(evento.ConsideracionesEspeciales))
                return false;

            return true;
        }
    }
}