using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  GarbageReport.Domain.DTOS.Requests;
using FluentValidation;

namespace GarbageReport.Infraestructure.Validators
{
    public class EventoCreateRequestValidatior : AbstractValidator<EventoCreateRequest>
    {
        public EventoCreateRequestValidatior()
        {
            RuleFor(e => e.NombredelEvento).NotNull().NotEmpty().Length(4, 200);
            RuleFor(e => e.DescripciondelEvento).NotNull().NotEmpty().Length(4, 400);
            RuleFor(e => e.FechadelEvento).NotNull().NotEmpty().MaximumLength(10).MinimumLength(10).Matches(DateTime.Today.ToString("yyyy-MM-dd")).WithMessage("El formato de la fecha no es el correcto, use el siguiente formato: 'yyyy-mm-dd'");
            RuleFor(e => e.UbicaciondelEvento).NotNull().NotEmpty().Length(4, 100);
            RuleFor(e => e.NdpersonasRequeridas).NotNull().NotEmpty().WithMessage("Ingrese un numero valido.");
            RuleFor(e => e.CaracteristicasdelEvento).NotNull().NotEmpty().Length(4, 400);
            RuleFor(e => e.Patrocinadores).NotNull().NotEmpty().Length(4, 100);
            RuleFor(e => e.ConsideracionesEspeciales).NotNull().NotEmpty().Length(4, 400);
        }
    }
}