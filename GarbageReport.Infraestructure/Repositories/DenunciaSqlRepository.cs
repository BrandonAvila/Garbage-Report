using System;
using System.Collections.Generic;
using System.Linq;
using GarbageReport.Infraestructure.Data;
using GarbageReport.Domain.Entities;
using GarbageReport.Domain.interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GarbageReport.Infraestructure.Repositories
{
    public class DenunciaSqlRepository : IDenunciaRepository
    {
        private readonly GarbageReportContext _context;

        public DenunciaSqlRepository(GarbageReportContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Denuncia>> TodosLosDatos()
        {
            var denuncia = _context.Denuncia.Select(dn => dn);
            return await denuncia.ToListAsync();
        }


        //Obtener por ID
        public async Task<Denuncia> PorID(int id)
        {
            var denuncia = await _context.Denuncia.FirstOrDefaultAsync(dn => dn.IdDenuncia == id);
            return denuncia;
        }


        //Crear denuncia
        public async Task<int> create(Denuncia denuncia)
        {
            var entity = denuncia;
            await _context.Denuncia.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows <= 0)
                throw new Exception("El registro no pudo ser completado");
            
            return entity.IdDenuncia;
        }

        //Actualizar denuncia
        public async Task<bool> Update(int id, Denuncia denuncia)
        {
            if(id <= 0 || denuncia == null)
                throw new ArgumentException("Falta informacion para poder realizar la modificacion");

            var entity = await PorID(id);

            entity.TitulodeDenuncia = denuncia.TitulodeDenuncia;
            entity.MotivodeDenuncia = denuncia.MotivodeDenuncia;
            entity.FechadeDenuncia = denuncia.FechadeDenuncia;
            entity.FotografiadelLugar = denuncia.FotografiadelLugar;
            entity.UbicaciondeDenuncia = denuncia.UbicaciondeDenuncia;

            

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public void EliminarDenuncia(int id)
        {
            var Eliminar = _context.Denuncia.FirstOrDefault(i => i.IdDenuncia == id);

            if(Eliminar!=null)
            {
                _context.Denuncia.Remove(Eliminar);
                _context.SaveChanges();
            }
        }
    }
}