using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  GarbageReport.Domain.DTOS.Requests;
using FluentValidation;

namespace GarbageReport.Infraestructure.Validators
{
    public class POICreateRequestValidator : AbstractValidator<POICreateRequest>
    {
        public POICreateRequestValidator()
        {
            RuleFor(p => p.Nombre).NotNull().NotEmpty().Length(10, 200);
            RuleFor(p => p.Descripcion).NotNull().NotEmpty().Length(10, 400);
            RuleFor(p => p.Ubicacion).NotNull().NotEmpty().Length(10, 100);
            RuleFor(p => p.Fecha).NotNull().NotEmpty().MaximumLength(10).MinimumLength(10).Matches(DateTime.Today.ToString("yyyy-MM-dd")).WithMessage("El formato de la fecha no es el correcto, use el siguiente formato: 'yyyy-mm-dd'");;
            RuleFor(p => p.Hora).NotNull().NotEmpty().MaximumLength(7).MinimumLength(7).WithMessage("El fortmato de la hora es incorrecto, pruebe con el formato: 'HH:MMpm/am'");
            RuleFor(p => p.Caracteristicas).NotNull().NotEmpty().Length(10, 400);
        }
    }
}