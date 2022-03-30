//cSpell:disable
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using GarbageReport.Infraestructure.Data;
using GarbageReport.Domain.interfaces;
using GarbageReport.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace GarbageReport.Infraestructure.Repositories
{
    public class POISSqlRepository : IPOISRepository
    {
        private readonly GarbageReportContext _context;

        public POISSqlRepository(GarbageReportContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Poi>> TodosLosDatos()
        {
            var encuentro = _context.Pois.Select(g => g);
            return await encuentro.ToListAsync();
        }

        public async Task<Poi> PorID(int id)
        {
            var poi = await _context.Pois.FirstOrDefaultAsync(dn => dn.IdPois == id);
            return poi;
        }


        //Crear denuncia
        public async Task<int> create(Poi poi)
        {
            var entity = poi;
            await _context.Pois.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("El registro no pudo ser completado");
            
            return entity.IdPois;
        }

        //Actualizar denuncia
        public async Task<bool> Update(int id, Poi poi)
        {
            if(id <= 0 || poi == null)
                throw new ArgumentException("Falta informacion para poder realizar la modificacion");

            var entity = await PorID(id);

            entity.Nombre = poi.Nombre;
            entity.Caracteristicas = poi.Caracteristicas;
            entity.Descripcion = poi.Descripcion;
            entity.Fecha = poi.Fecha;
            entity.Hora = poi.Hora;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public void EliminarPOI(int id)
        {
            var Eliminar = _context.Pois.FirstOrDefault(i => i.IdPois == id);

            if(Eliminar!=null)
            {
                _context.Pois.Remove(Eliminar);
                _context.SaveChanges();
            }
        }
    }
}