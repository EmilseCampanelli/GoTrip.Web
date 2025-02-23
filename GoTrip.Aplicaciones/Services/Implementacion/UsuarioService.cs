using AutoMapper;
using FluentValidation;
using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Services.Interfaces;
using GoTrip.Aplicaciones.Validations;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using GoTrip.Dominio.Enums;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Activate(int id)
        {
            var usuario = await _repository.Get(id);
            usuario.State = BaseState.Activo;
            await _repository.Update(usuario);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repository.Get(id) != null;
        }

        public async Task<UsuarioDto> Get(int id)
        {
            var model = await _repository.Get(id);
            return _mapper.Map<UsuarioDto>(model);
        }

        public async Task<List<UsuarioDto>> GetAll()
        {
            var usuarios = await _repository.GetAll();
            return _mapper.Map<List<UsuarioDto>>(usuarios);
        }

        public async Task Inactivate(int id)
        {
            var usuario = await _repository.Get(id);
            usuario.State = BaseState.Inactivo;
            await _repository.Update(usuario);
        }

        public async Task<UsuarioDto> Save(UsuarioDto dto)
        {
            var user = await _repository.GetUserByUsername(dto.UserName);

            Usuario usuario = new Usuario();
            if (dto.Id.Equals(0))
            {
                if (user != null)
                {
                    if (user.Email == dto.Email || user.Documento == dto.Documento)
                    {
                        throw new Exception("El usuario que desea ingresar ya existe.");
                    }
                }
                var newUsuario = _mapper.Map<Usuario>(dto);
                newUsuario.State = BaseState.Activo;
                newUsuario.Password = dto.Password;
                usuario = await _repository.Add(newUsuario);
            }
            else
            {
                var updatedUsuario = _mapper.Map<Usuario>(dto);
                updatedUsuario.Password = dto.Password;
                usuario = await _repository.Update(updatedUsuario);
            }
            return _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<(bool isValid, string message)> Validate(int? id, UsuarioDto dto)
        {
            var validations = new List<(bool isValid, string message)>();

            var validator = new UsuarioValidate();
            var result = await validator.ValidateAsync(dto);
            validations.Add((result.IsValid, string.Join(Environment.NewLine, result.Errors.Select(x => $"Campo {x.PropertyName} invalido. Error: {x.ErrorMessage}"))));

            return (isValid: validations.All(x => x.isValid),
                    message: string.Join(Environment.NewLine, validations.Where(x => !x.isValid).Select(x => x.message)));
        }
    }
}
