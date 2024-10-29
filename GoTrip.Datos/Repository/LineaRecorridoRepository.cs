using GoTrip.Datos.Context;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Datos.Repository
{
    public class LineaRecorridoRepository : GenericRepository<LineaRecorrido>, ILineaRecorridoRepository
    {
        public LineaRecorridoRepository(GoTripContext context) : base(context)
        {
        }

        public async Task SaveAll(List<LineaRecorrido> list)
        {
            await _dbSet.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAll(List<LineaRecorrido> list)
        {
            foreach (var item in list)
            {
                // Verifica si el objeto ya está en el contexto
                var localEntity = _dbSet.Local.FirstOrDefault(x => x.Id == item.Id);

                // Si está en el contexto, desvincúlalo para evitar conflictos
                if (localEntity != null)
                    _context.Entry(localEntity).State = EntityState.Detached;

                // Marca el objeto como modificado
                _context.Entry(item).State = EntityState.Modified;
            }

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();
        }
    }
}
