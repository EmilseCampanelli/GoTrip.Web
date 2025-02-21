using GoTrip.Dominio.Entidades;
using System.Linq.Expressions;

namespace GoTrip.Dominio.Contratos
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Add(TEntity item);

        TEntity Update(TEntity item);

        Task<TEntity> Get(int id);

        Task<IEnumerable<TEntity>> GetAll();

        IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);

        //Task<IEnumerable<T>> ExecuteQuery<T>(string sqlQuery, params object[] parameters);
        Task Delete(TEntity item);

        Task Save();

        void AddRangeAsync(List<TEntity> items);

        void DeleteRange(List<TEntity> entities);
    }
}
