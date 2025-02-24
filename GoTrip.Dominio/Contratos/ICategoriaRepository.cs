using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Dominio.Contratos
{
    public interface ICategoriaRepository
    {
       Task<Categoria> GetCategoriaByDescripcion(string descripcion);
    }
}
