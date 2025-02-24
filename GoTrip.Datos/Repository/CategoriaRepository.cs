using GoTrip.Datos.Context;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Datos.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly GoTripContext _context;
        protected DbSet<Categoria> _dbSet;

        public CategoriaRepository(GoTripContext context)
        {
            _context = context;
            _dbSet = _context.Set<Categoria>();
        }

        async Task<Categoria> ICategoriaRepository.GetCategoriaByDescripcion(string descripcion)
        {
            return await _dbSet.Where(u => u.Descripcion == descripcion).FirstOrDefaultAsync();
        }
    }
}
