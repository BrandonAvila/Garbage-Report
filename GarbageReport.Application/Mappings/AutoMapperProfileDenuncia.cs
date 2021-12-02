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
    public class AutoMapperProfileDenuncia : Profile
    {
        public AutoMapperProfileDenuncia()
        {
            CreateMap<Denuncia, DenunciaResponses>()

            .ForMember(dest => dest.InformacionDen, opt => opt.MapFrom(src => $"El motivo fue: {src.MotivodeDenuncia} y se registro en la fecha: {src.FechadeDenuncia}"))
            .ForMember(dest => dest.LugarDen, opt => opt.MapFrom(src => $"Ubicado en: {src.UbicaciondeDenuncia} en la colonia: {src.ColoniadelEvento}"));

            CreateMap<DenunciaCreateRequest, Denuncia>();
        }
    }
}