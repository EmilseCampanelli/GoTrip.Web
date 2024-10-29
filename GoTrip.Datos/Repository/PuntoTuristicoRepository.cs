using GoTrip.Datos.Context;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Datos.Repository
{
    public class PuntoTuristicoRepository : GenericRepository<PuntoTuristico>, IPuntoTuristicoRepository
    {
        public PuntoTuristicoRepository(GoTripContext context) : base(context) { }

        // Método para obtener un PuntoTuristico por id con sus relaciones
        public async Task<PuntoTuristico> GetPunto(int id)
        {
            return await _dbSet
                .Include(p => p.Ubicacion)
                .Include(p => p.Categoria)
                .Include(p => p.Comentarios)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Método para obtener todos los PuntoTuristico con sus relaciones
        public async Task<IEnumerable<PuntoTuristico>> GetPuntosTuristicos()
        {
            return await _dbSet
                .Include(p => p.Ubicacion)
                .Include(p => p.Categoria)
                .Include(p => p.Comentarios)
                .ToListAsync();
        }
    }
}
