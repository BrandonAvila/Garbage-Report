using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GarbageReport.Domain.Entities;
using GarbageReport.Domain.DTOS.Responses;
using GarbageReport.Domain.DTOS.Requests;

namespace GarbageReport.Application.Mappings
{
    public class AutoMappperProfileEvento : Profile
    {
        public AutoMappperProfileEvento()
        {
            CreateMap<Evento, EventoResponses>()

            .ForMember(dest => dest.InfoEvento, opt => opt.MapFrom(src => $"El evento: {src.NombredelEvento} se registro en la siguiente fecha {src.FechadelEvento}"));

            CreateMap<EventoCreateRequest, Evento>();
        }
    }
}