using BCrypt.Net;
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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GoTripContext _context;
        protected DbSet<Usuario> _dbSet;

        public UsuarioRepository(GoTripContext context)
        {
            _context = context;
            _dbSet = _context.Set<Usuario>();
        }

        public async Task<Usuario> Add(Usuario item)
        {
            _dbSet.Add(item);
            await Save();
            return item;
        }

        public async Task Delete(Usuario item)
        {
            _dbSet.Remove(item);
            await Save();
        }

        public async Task<Usuario> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<Usuario> GetFiltered(Expression<Func<Usuario, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> Update(Usuario item)
        {
            var localEntity = _dbSet.Local.FirstOrDefault(x => x.Id == item.Id);
            if (localEntity != null)
                _context.Entry(localEntity).State = EntityState.Detached;
            _context.Entry(item).State = EntityState.Modified;
            await Save();
            return item;
        }

        public async Task<Usuario> GetUserByUsername(string userName)
        {
            return await _dbSet.Where(u => u.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task<bool> ValidatePasswordAsync(Usuario user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

    }
}
