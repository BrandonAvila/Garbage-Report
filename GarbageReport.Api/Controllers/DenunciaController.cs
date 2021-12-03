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
    [ApiController]
    [Route("api/[controller]")]
    public class DenunciaController : ControllerBase
    {
        private readonly IDenunciaRepository _repository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IDenunciaService _service;
        private readonly IValidator<DenunciaCreateRequest> _createValidator;

        public DenunciaController(IDenunciaRepository repository, 
        IHttpContextAccessor httpContext, 
        IMapper mapper, 
        IDenunciaService service, 
        IValidator<DenunciaCreateRequest> createValidator)
        
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
            var denuncias = await _repository.TodosLosDatos();
            //var RespuestaDenuncia = denuncias.Select(g => CreateDtoFromObject(g));
            var RespuestaDenuncia = _mapper.Map<IEnumerable<Denuncia>,IEnumerable<DenunciaResponses>>(denuncias);
            return Ok(RespuestaDenuncia);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> PorID(int id)
        {
            var denuncia = await _repository.PorID(id);

            if(denuncia == null)
                return NotFound("Lo sentimos, su denuncia no fue encontrada.");

            var respuesta = _mapper.Map<Denuncia, DenunciaResponses>(denuncia);

            return Ok(respuesta);
        }

        /*[HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update (int id,[FromBody]Denuncia denuncia)
        {
            if(id <= 0)
                return NotFound("No se encontro el regsitro de la denuncia.");
            
            denuncia.IdDenuncia = id;

            var Validated = _service.ValidatedUpdate(denuncia);

            if(!Validated)
                UnprocessableEntity("No es posible actualizar la informacion.");
            
            var updated = await _repository.Update(id, denuncia);

            if(!updated)
                Conflict("Ocurrio un fallo al intentar actualizar la denuncia.");
            
            return NoContent();
        }*/

        [HttpPost]
        
        public async Task<IActionResult> create(DenunciaCreateRequest denuncia)
        {
            
            var Val = await _createValidator.ValidateAsync(denuncia);

           // var Val = _service.Validated(entity);

            if(!Val.IsValid)
                return UnprocessableEntity (Val.Errors.Select(d => $"{d.PropertyName} => Error: {d.ErrorMessage}"));

            var entity = _mapper.Map<DenunciaCreateRequest, Denuncia>(denuncia);

            var id = await _repository.create(entity);
            
            if(id <= 0)
                return Conflict("Fallo el registro, intente de nuevo.");

            var host = _httpContext.HttpContext.Request.Host.Value;
            var urlResult = $"https://{host}/api/Denuncias/{id}";
            return Created(urlResult, id);
        }

        #region"Request"
        private Denuncia CreateObjectFromDto(DenunciasRequest dto)
        {
            var denuncia = new Denuncia {
                IdDenuncia = 0,
                FechadeDenuncia = string.Empty,
                MotivodeDenuncia = string.Empty,
                DescripciondeSituacion = string.Empty,
                UbicaciondeDenuncia = string.Empty,
                ColoniadelEvento = string.Empty,
                FotografiadelLugar = string.Empty

            };
            return denuncia;
        }
        #endregion
    }

}