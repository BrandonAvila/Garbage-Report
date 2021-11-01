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
    [ApiController]
    [Route("api/[controller]")]
    public class PoiController : ControllerBase
    {
        //Retorna todos los pois
        //Ejemplo para Thunder client: https://localhost:5001/api/Poi/Todos
        [HttpGet]
        [Route("Todos")]
        public IActionResult TodosLosDatos()
        {
            var repository = new POISSqlRepository();
            var Garbages = repository.TodosLosDatos();
            var Respuesta = Garbages.Select(g => CreateDtoFromObject(g));
            return Ok(Respuesta);
        } 

        //Retorna los pois por nombre
        //Ejemplo para Thunder client: https://localhost:5001/api/Poi/BuscarPorNombre/Fuller
        [HttpGet]
        [Route("BuscarPorNombre/{nombre}")]
        public IActionResult BuscarNombre(string nombre)
        {
            var repository = new POISSqlRepository();
            var Garbages = repository.BuscarNombre(nombre);
            return Ok(Garbages);
        } 

        private POISResponse CreateDtoFromObject(Poi pois)
        {
            var dtos = new POISResponse(

                nombre : pois.Nombre,
                PoiDescripcion : pois.Descripcion,
                ubicacion : pois.Ubicacion,
                caracteristica : pois.Caracteristicas
            );
            return dtos;
        }

        #region"Request"
        private Poi CreateObjectFromDto(POISRequest dto)
        {
            var poi = new Poi {
                IdPois = 0,
                Nombre = string.Empty,
                Descripcion = string.Empty,
                Ubicacion = string.Empty,
                Fecha = dto.Fecha.Date,
                Caracteristicas = string.Empty

            };
            return poi;
        }
        #endregion

    }
}
