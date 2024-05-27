using GoTrip.Dominio.Entidades;
using System.Linq.Expressions;

namespace GoTrip.Dominio.Contratos
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Add(TEntity item);

        Task<TEntity> Update(TEntity item);

        Task<TEntity> Get(int id);

        Task<IEnumerable<TEntity>> GetAll();

        IQueryable<TEntity> GetFiltered(Expression<Func<TEntity, bool>> filter);

       //Task<IEnumerable<T>> ExecuteQuery<T>(string sqlQuery, params object[] parameters);

        Task Save();
    }
}
