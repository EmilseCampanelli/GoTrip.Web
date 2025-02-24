using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Dominio.Contratos
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Add(Usuario item);

        Task<Usuario> Update(Usuario item);

        Task<Usuario> Get(int id);

        Task<IEnumerable<Usuario>> GetAll();

        IQueryable<Usuario> GetFiltered(Expression<Func<Usuario, bool>> filter);

        //Task<IEnumerable<T>> ExecuteQuery<T>(string sqlQuery, params object[] parameters);
        Task Delete(Usuario item);

        Task Save();

        Task<Usuario> GetUserByUsername(string username);
        Task<Usuario> GetUserByEmail(string email);
        Task<Usuario> GetUserByDocumento(double documento);

        Task<bool> ValidatePasswordAsync(Usuario user, string password);
    }
}
