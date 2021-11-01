//cSpell:disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GarbageReport.Infraestructure.Repositories;
using GarbageReport.Domain.Entities;
using GarbageReport.Domain.DTOS;
using System.Security.AccessControl;
using System.Runtime.InteropServices;

namespace GarbageReport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {
        }

        [HttpGet]
        [Route("Todos")]
        public IActionResult TodosLosDatos()
        {
            var repository = new EventoSqlRepository();
            var eventos = repository.TodosLosDatos();
            var RespuestaEventos = eventos.Select(et => CreateDtoFromObject(et));
            return Ok(RespuestaEventos);
        }

        private EventoResponse CreateDtoFromObject(Evento eventos)
        {
            var dtos = new EventoResponse(

                Nombre : eventos.NombredelEvento, 
                Descripcion : eventos.DescripciondelEvento, 
                Fecha : eventos.FechadelEvento, 
                Ubicacion : eventos.UbicaciondelEvento, 
                personalRequerido : eventos.NdpersonasRequeridas
            );
            return dtos;
        }

        #region"Request"
        private Evento CreateObjectFromDto(EventoRequest dto)
        {
            var evento = new Evento {
                IdEventos = 0,
                NombredelEvento = string.Empty,
                DescripciondelEvento = string.Empty,
                FechadelEvento = dto.FechadelEvento.Date,
                UbicaciondelEvento = string.Empty,
                NdpersonasRequeridas = 0,
                CaracteristicasdelEvento = string.Empty,
                Patrocinadores = string.Empty,
                ConsideracionesEspeciales = string.Empty

            };
            return evento;
        }
        #endregion

    }
}