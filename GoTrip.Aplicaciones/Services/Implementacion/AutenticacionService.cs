using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Services.Interfaces;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Implementacion
{
    public class AutenticacionService : IAutenticacionService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AutenticacionService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<AutenticacionResponse> Login(string username, string password)
        {
            var usuario = await _usuarioRepository.GetUserByUsername(username);

            if (usuario == null)
            {
                throw new UnauthorizedAccessException("El usuario con el que desea ingresar no existe.");
            }
            if (!usuario.State.Equals(BaseState.Activo))
            {
                throw new UnauthorizedAccessException("El usuario no se encuentra activo en este momento.");
            }
            if (!await _usuarioRepository.ValidatePasswordAsync(usuario, password))
            {
                throw new UnauthorizedAccessException("La contraseña con la que desea ingresar es incorrecta.");
            }

            AutenticacionResponse response = new AutenticacionResponse();

            response.Token = ""; //Si se desea implementar JWT queda preparado
            response.UserName = usuario.UserName;
            response.IsAuthenticated = true;
            response.UserId = usuario.Id;
            response.IsNoVidente = (usuario.IsNoVidente != null ? usuario.IsNoVidente.Value : false);

            return response;

        }
    }
}
