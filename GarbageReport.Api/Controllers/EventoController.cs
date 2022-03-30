//cSpell:disable
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GarbageReport.Infraestructure.Repositories;
using GarbageReport.Domain.Entities;
using GarbageReport.Domain.DTOS;
using GarbageReport.Domain.DTOS.Responses;
using GarbageReport.Domain.DTOS.Requests;
using System.Security.AccessControl;
using System.Runtime.InteropServices;
using GarbageReport.Domain.interfaces;
using AutoMapper;
using FluentValidation;

/*Nombre de la escuela: Universidad Tecnologica Metropolitana
Asignatura: Aplicaciones Web Orientadas a Servicios
Nombre del Maestro: Chuc Uc Joel Ivan
Nombre del Proyecto: Garbage Report
Integrantes:
- Avila Ramayo Brandon Jefte
- Paredes Ayala Guillermo Aldair
- Lopez Canul Joatan de Jesus
Cuatrimestre: 4
Grupo: B
Parcial: 2
*/

namespace GarbageReport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _repository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IEventoService _service;
        private readonly IValidator<EventoCreateRequest> _createValidator;

        public EventoController(IEventoRepository repository, IHttpContextAccessor httpContext, IMapper mapper, IEventoService service, IValidator<EventoCreateRequest> createValidator)
        {
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
            this._service = service;
            this._createValidator = createValidator;
        }

        [HttpGet]
        [Route("Todos")]
        public async Task<IActionResult> TodosLosDatos()
        {
            var eventos = await _repository.TodosLosDatos();
            //var RespuestaEventos = eventos.Select(et => CreateDtoFromObject(et));
            // var RespuestaEvento = _mapper.Map<IEnumerable<Evento>,IEnumerable<EventoResponses>>(eventos);
            return Ok(eventos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> PorID(int id)
        {
            var evento = await _repository.PorID(id);
            if(evento == null)
                return NotFound("Lo sentimos, su evento no fue encontrado.");

                // var respuesta = _mapper.Map<Evento, EventoResponses>(evento);
            return Ok(evento);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update (int id,[FromBody]Evento evento)
        {
            if(id <= 0)
                return NotFound("No se encontro el evento");
            
            evento.IdEventos = id;

            var Validated = _service.ValidatedUpdateEvento(evento);

            if(!Validated)
                UnprocessableEntity("No es posible actualizar la informacion.");

            var updated = await _repository.Update(id, evento);

            if(!updated)
                Conflict("Ocurrio un fallo al intentar actualizar el evento.");
            
            return NoContent();
        }

        [HttpPost]
        
        public async Task<IActionResult> create(EventoCreateRequest evento)
        {

            var Val = await _createValidator.ValidateAsync(evento);

            //var Val = _service.ValidatedEvento(entity);

            if(!Val.IsValid)
                return UnprocessableEntity (Val.Errors.Select(d => $"{d.PropertyName} => Error: {d.ErrorMessage}"));
            
            var entity = _mapper.Map<EventoCreateRequest, Evento>(evento);

            var id = await _repository.create(entity);
            
            if(id <= 0)
                return Conflict("Fallo el registro, intente de nuevo");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/api/Eventos/{id}";
            return Created(urlResult, id);
        }
    }
}