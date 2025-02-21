using GoTrip.Datos.Context;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GoTrip.Datos.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly GoTripContext _context;
        protected DbSet<TEntity> _dbSet;

        public GenericRepository(GoTripContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity item)
        {
            _dbSet.Add(item);
            await Save();
            return item;
        }

        public TEntity Update(TEntity item)
        {
            var localEntity = _dbSet.Local.FirstOrDefault(x => x.Id == item.Id);
            if (localEntity != null)
                _context.Entry(localEntity).State = EntityState.Detached;
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }

        public async Task<TEntity> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        //TODO: Validar ya que es una sql query
        /*public async Task<IEnumerable<T>> ExecuteQuery<T>(string sqlQuery, params object[] parameters)
        {
            return _context<T>(sqlQuery, parameters);
        }*/

        public async Task Delete(TEntity item)
        {
            _dbSet.Remove(item);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void AddRangeAsync(List<TEntity> items)
        {
            if(items == null || !items.Any())
            {
                throw new ArgumentException("La lista de entidades no puede estar vacía.", nameof(items));

            }
            _dbSet.AddRange(items);
            _context.SaveChanges();
        }
        public void DeleteRange(List<TEntity> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentException("La lista de entidades no puede estar vacía.", nameof(entities));

            _dbSet.RemoveRange(entities);
             _context.SaveChanges();
        }
    }
}
