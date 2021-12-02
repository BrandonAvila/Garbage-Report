//cSpell:disable
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using GarbageReport.Domain.interfaces;
using System.Linq;
using GarbageReport.Infraestructure.Data;
using GarbageReport.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GarbageReport.Infraestructure.Repositories
{
    public class EventoSqlRepository : IEventoRepository
    {
        private readonly GarbageReportContext _context;

        public EventoSqlRepository(GarbageReportContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> TodosLosDatos()
        {
            var evento = _context.Eventos.Select(et => et);
            return await evento.ToListAsync();
        }

        public async Task<Evento> PorID(int id)
        {
            var evento = await _context.Eventos.FirstOrDefaultAsync(et => et.IdEventos == id);
            return evento;
        }

        public async Task<int> create(Evento evento)
        {
            var entity = evento;
            await _context.Eventos.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("El registro no pudo ser completado");
            
            return entity.IdEventos;
        }

        public async Task<bool> Update(int id, Evento evento)
        {
            if(id <= 0 || evento == null)
                throw new ArgumentException("Falta informacion para poder realizar la modificacion");

            var entity = await PorID(id);

            entity.NombredelEvento = evento.NombredelEvento;
            entity.DescripciondelEvento = evento.DescripciondelEvento;
            entity.FechadelEvento = evento.FechadelEvento;
            entity.UbicaciondelEvento = evento.UbicaciondelEvento;
            entity.NdpersonasRequeridas = evento.NdpersonasRequeridas;
            entity.CaracteristicasdelEvento = evento.CaracteristicasdelEvento;
            entity.Patrocinadores = evento.Patrocinadores;
            entity.ConsideracionesEspeciales = evento.ConsideracionesEspeciales;

        
            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            
            return rows > 0;
        }
    }
}