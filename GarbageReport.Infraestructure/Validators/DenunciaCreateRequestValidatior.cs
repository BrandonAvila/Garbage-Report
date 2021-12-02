using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  GarbageReport.Domain.DTOS.Requests;
using FluentValidation;

namespace GarbageReport.Infraestructure.Validators
{
    public class DenunciaCreateRequestValidatior : AbstractValidator<DenunciaCreateRequest>
    {
        public DenunciaCreateRequestValidatior()
        {
            RuleFor(d => d.FechadeDenuncia).NotNull().NotEmpty().MaximumLength(10).MinimumLength(10).Matches(DateTime.Today.ToString("yyyy-MM-dd")).WithMessage("El formato de la fecha no es el correcto, use el siguiente formato: 'yyyy-mm-dd'");
            //RuleFor(d => d.FechadeDenuncia).Matches("YYYY/MM/dd");
            RuleFor(d => d.MotivodeDenuncia).NotNull().NotEmpty().Length(10, 400);
            RuleFor(d => d.DescripciondeSituacion).NotNull().NotEmpty().Length(10, 400);
            RuleFor(d => d.UbicaciondeDenuncia).NotNull().NotEmpty().Length(10, 100);
            RuleFor(d => d.ColoniadelEvento).NotNull().NotEmpty().Length(10, 100);
            RuleFor(d => d.FotografiadelLugar).NotNull().NotEmpty().Length(10, 100).Matches(".jpg").WithMessage("Falta la terminacion '.jpg' al archivo, favor de agregarsela");
        }
    }
}