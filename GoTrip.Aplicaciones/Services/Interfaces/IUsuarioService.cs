using GoTrip.Aplicaciones.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> Get(int id);
        Task<List<UsuarioDto>> GetAll();
        Task<bool> Exists(int id);
        Task Activate(int id);
        Task Inactivate(int id);
        Task<UsuarioDto> Save(UsuarioDto dto);
        Task<(bool isValid, string message)> Validate(int? id, UsuarioDto dto);
    }
}
