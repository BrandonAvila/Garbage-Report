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
            entity.ConsideracionesEspeciales = evento.ConsideracionesEspeciales;
            entity.FechadelEvento = evento.FechadelEvento;
            entity.NdpersonasRequeridas = evento.NdpersonasRequeridas;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            
            return rows > 0;
        }

        public void EliminarEvento(int id)
        {
            var Eliminar = _context.Eventos.FirstOrDefault(i => i.IdEventos == id);

            if(Eliminar!=null)
            {
                _context.Eventos.Remove(Eliminar);
                _context.SaveChanges();
            }
        }
    }
}