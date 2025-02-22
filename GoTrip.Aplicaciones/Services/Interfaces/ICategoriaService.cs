using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Helper;
using GoTrip.Aplicaciones.Services.Implementacion;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Interfaces
{
    public interface ICategoriaService : IGenericService<CategoriaDto>
    {
        Task<CategoriaDto> Save(CategoriaDto categoria);

        Task Delete(int id);

        Task<List<CategoriaDto>> GetActiveCategories();
    }
}
