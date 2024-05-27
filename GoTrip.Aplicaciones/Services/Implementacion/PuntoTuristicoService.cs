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
    public class PuntoTuristicoService : IPuntoTuristicoService
    {

        private readonly IRepository<PuntoTuristico> _repository;
        private readonly IMapper _mapper;
        private const int _usuarioId = 1; //TODO: Modificar por el codigo del usuario autenticado

        public PuntoTuristicoService(IRepository<PuntoTuristico> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task Activate(int id)
        {
            var puntoTuristico = await _repository.Get(id);
            BaseEntityHelper.SetActive(puntoTuristico, _usuarioId);
            await _repository.Update(puntoTuristico);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repository.Get(id) != null;
        }

        public async Task<PuntoTuristicoDto> Get(int id)
        {
            var model = await _repository.Get(id);
            return _mapper.Map<PuntoTuristicoDto>(model);
        }

        public async Task Inactivate(int id)
        {
            var puntoTuristico = await _repository.Get(id);
            BaseEntityHelper.SetInactive(puntoTuristico, _usuarioId);
            await _repository.Update(puntoTuristico);
        }

        public async Task Save(PuntoTuristicoDto dto)
        {
            if (dto.Id.Equals(0))
            {
                var newPuntoTuristico = _mapper.Map<PuntoTuristico>(dto);
                BaseEntityHelper.SetCreated(newPuntoTuristico, _usuarioId);
                await _repository.Add(newPuntoTuristico);
            }
            else
            {
                var updatedPuntoTuristico = _mapper.Map<PuntoTuristico>(dto);
                BaseEntityHelper.SetUpdated(updatedPuntoTuristico, _usuarioId);
                await _repository.Update(updatedPuntoTuristico);
            }
        }

        public async Task<(bool isValid, string message)> Validate(int? id, PuntoTuristicoDto dto)
        {
            var validations = new List<(bool isValid, string message)>();

            var validator = new PuntoTuristicoValidators();
            var result = await validator.ValidateAsync(dto);
            validations.Add((result.IsValid, string.Join(Environment.NewLine, result.Errors.Select(x => $"Campo {x.PropertyName} invalido. Error: {x.ErrorMessage}"))));

            return (isValid: validations.All(x => x.isValid),
                    message: string.Join(Environment.NewLine, validations.Where(x => !x.isValid).Select(x => x.message)));
        }
    }
}
