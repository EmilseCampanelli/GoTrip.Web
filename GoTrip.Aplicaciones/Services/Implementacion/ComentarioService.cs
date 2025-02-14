using AutoMapper;
using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Helper;
using GoTrip.Aplicaciones.Services.Interfaces;
using GoTrip.Aplicaciones.Validations;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Implementacion
{
    public class ComentarioService : IComentarioService
    {
        private readonly IRepository<Comentario> _repository;
        private readonly IMapper _mapper;
        private const int _usuarioId = 1; //TODO: Modificar por el codigo del usuario autenticado

        public ComentarioService(IRepository<Comentario> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<List<ComentarioDto>> GetComentariosPuntoTuristico(int idPuntoTuristico) 
        {
            var comentarios = await _repository.GetAll();

            if (comentarios == null || !comentarios.Any())
            {
                throw new Exception("Comentarios no encontrados");
            }

            var comentariosPtoTuristico = comentarios
                .Where(o => o.PuntoTuristicoId == idPuntoTuristico)
                .Select(comentario => _mapper.Map<ComentarioDto>(comentario))
                .ToList();

            return comentariosPtoTuristico;
        }

        public async Task<List<ComentarioDto>> GetComentariosEvento(int idEvento)
        {
            var comentarios = await _repository.GetAll();

            if (comentarios == null || !comentarios.Any())
            {
                throw new Exception("Comentarios no encontrados");
            }

            var comentariosEventos = comentarios
                .Where(o => o.PuntoTuristicoId == idEvento)
                .Select(comentario => _mapper.Map<ComentarioDto>(comentario))
                .ToList();

            return comentariosEventos;
        }

        public async Task<bool> Exists(int id)
        {
            return await _repository.Get(id) != null;
        }

        public async Task Activate(int id)
        {
            var comentario = await _repository.Get(id);
            BaseEntityHelper.SetActive(comentario, _usuarioId);
            await _repository.Update(comentario);
        }

        public async Task Inactivate(int id)
        {
            var comentario = await _repository.Get(id);
            BaseEntityHelper.SetInactive(comentario, _usuarioId);
            await _repository.Update(comentario);
        }

        public async Task<ComentarioDto> Save(ComentarioDto dto)
        {
            Comentario comentario = new Comentario();
            if (dto.Id.Equals(0))
            {
                var comentario1 = _mapper.Map<Comentario>(dto);
                BaseEntityHelper.SetCreated(comentario1, _usuarioId);
                await _repository.Add(comentario1);
            }
            else
            {
                var updatedComentario = _mapper.Map<Comentario>(dto);
                BaseEntityHelper.SetUpdated(updatedComentario, _usuarioId);
                await _repository.Update(updatedComentario);
            }
            return _mapper.Map<ComentarioDto>(dto);
        }

        public async Task<(bool isValid, string message)> Validate(int? id, ComentarioDto dto)
        {
            var validations = new List<(bool isValid, string message)>();

            var validator = new ComentarioValidators();
            var result = await validator.ValidateAsync(dto);
            validations.Add((result.IsValid, string.Join(Environment.NewLine, result.Errors.Select(x => $"Campo {x.PropertyName} invalido. Error: {x.ErrorMessage}"))));

            return (isValid: validations.All(x => x.isValid),
                    message: string.Join(Environment.NewLine, validations.Where(x => !x.isValid).Select(x => x.message)));
        }

        public async Task<ComentarioDto> Get(int id)
        {
            var model = await _repository.Get(id);
            return _mapper.Map<ComentarioDto>(model);
        }

        public Task<List<ComentarioDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
