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
    public class AutoMapperProfilePOI : Profile
    {
        public AutoMapperProfilePOI()
        {
            CreateMap<Poi, POIResponses>()

            .ForMember(dest => dest.Informacion_POI, opt => opt.MapFrom(src => $"El nombre del POI es: {src.Nombre} breve descripcion:  {src.Descripcion}"))
            .ForMember(dest => dest.Lugar_y_Fecha, opt => opt.MapFrom(src => $"Ubicado en: {src.Ubicacion} registrado el dia: {src.Fecha}"));

            CreateMap<POICreateRequest, Poi>();
        }
    }
}