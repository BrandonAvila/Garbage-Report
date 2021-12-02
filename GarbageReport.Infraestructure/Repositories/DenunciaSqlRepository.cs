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
            var denuncia = _context.Denuncias.Select(dn => dn);
            return await denuncia.ToListAsync();
        }


        //Obtener por ID
        public async Task<Denuncia> PorID(int id)
        {
            var denuncia = await _context.Denuncias.FirstOrDefaultAsync(dn => dn.IdDenuncia == id);
            return denuncia;
        }


        //Crear denuncia
        public async Task<int> create(Denuncia denuncia)
        {
            var entity = denuncia;
            await _context.Denuncias.AddAsync(entity);
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

            entity.FechadeDenuncia = denuncia.FechadeDenuncia;
            entity.MotivodeDenuncia = denuncia.MotivodeDenuncia;
            entity.DescripciondeSituacion = denuncia.DescripciondeSituacion;
            entity.UbicaciondeDenuncia = denuncia.UbicaciondeDenuncia;
            entity.ColoniadelEvento = denuncia.ColoniadelEvento;
            entity.FotografiadelLugar = denuncia.FotografiadelLugar;

            

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

    }
}