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
Parcial: 3
*/

namespace GarbageReport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoiController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IPOISService _service;
        private readonly IValidator<POICreateRequest> _createValidator;
        private readonly IPOISRepository _repository;
        public PoiController(IPOISRepository repository, 
        IHttpContextAccessor httpContext, 
        IMapper mapper, 
        IPOISService service, 
        IValidator<POICreateRequest> createValidator)
        {
            this._repository = repository;
            this._httpContext = httpContext;
            this._mapper = mapper;
            this._service = service;
            this._createValidator = createValidator;
        }


        //Retorna todos los pois
        //Ejemplo para Thunder client: https://localhost:5001/api/Poi/Todos
        [HttpGet]
        [Route("Todos")]
        public async  Task<IActionResult> TodosLosDatos()
        {
            var pois = await _repository.TodosLosDatos();
            //var Respuesta = Garbages.Select(g => CreateDtoFromObject(g));
            var RespuestaPOI = _mapper.Map<IEnumerable<Poi>,IEnumerable<POIResponses>>(pois);
            return Ok(RespuestaPOI);
        } 

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> PorID(int id)
        {
            var poi = await _repository.PorID(id);

            if(poi == null)
                return NotFound("Lo sentimos, el poi no fue encontrado.");

            var respuesta = _mapper.Map<Poi, POIResponses>(poi);

            return Ok(respuesta);
        }

        [HttpPost]
        
        public async Task<IActionResult> create(POICreateRequest poi)
        {
            var Val = await _createValidator.ValidateAsync(poi);
            

            //var Val = _service.ValidatedPOI(entity);

            if(!Val.IsValid)
                return UnprocessableEntity (Val.Errors.Select(d => $"{d.PropertyName} => Error: {d.ErrorMessage}"));

            var entity = _mapper.Map<POICreateRequest, Poi>(poi);

            var id = await _repository.create(entity);
            
            if(id <= 0)
                return Conflict("Fallo el registro, intente de nuevo");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/api/Eventos/{id}";
            return Created(urlResult, id);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update (int id,[FromBody]Poi poi)
        {
            if(id <= 0)
                return NotFound("No se encontro el regsitro de la denuncia.");
            
            poi.IdPois = id;

            var Validated = _service.ValidatedUpdatePOI(poi);

            if(!Validated)
                UnprocessableEntity("No es posible actualizar la informacion.");
            
            var updated = await _repository.Update(id, poi);

            if(!updated)
                Conflict("Ocurrio un fallo al intentar actualizar la denuncia.");
            
            return NoContent();
        }

        #region"Request"
        private Poi CreateObjectFromDto(POISRequest dto)
        {
            var poi = new Poi {
                IdPois = 0,
                Nombre = string.Empty,
                Descripcion = string.Empty,
                Ubicacion = string.Empty,
                Fecha = string.Empty,
                Caracteristicas = string.Empty

            };
            return poi;
        }
        #endregion

    }
}
