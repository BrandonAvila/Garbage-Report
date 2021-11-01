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
    public class DenunciaController : ControllerBase
    {
        [HttpGet]
        [Route("Todos")]
        public IActionResult TodosLosDatos()
        {
            var repository = new DenunciaSqlRepository();
            var denuncias = repository.TodosLosDatos();
            var RespuestaDenuncia = denuncias.Select(g => CreateDtoFromObject(g));
            return Ok(RespuestaDenuncia);
        }

        private DenunciaResponse CreateDtoFromObject(Denuncia denuncias)
        {
            var dtos = new DenunciaResponse(

                Fecha : denuncias.FechadeDenuncia,
                Motivo : denuncias.MotivodeDenuncia,
                Descripcion : denuncias.DescripciondeSituacion,
                Ubicacion : denuncias.UbicaciondeDenuncia,
                Colonia : denuncias.ColoniadelEvento
            );
            return dtos;
        }

        #region"Request"
        private Denuncia CreateObjectFromDto(DenunciasRequest dto)
        {
            var denuncia = new Denuncia {
                IdDenuncia = 0,
                FechadeDenuncia = dto.FechadeDenuncia.Date,
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