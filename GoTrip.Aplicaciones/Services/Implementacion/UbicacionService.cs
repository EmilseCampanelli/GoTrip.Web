using AutoMapper;
using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Helper;
using GoTrip.Aplicaciones.Services.Interfaces;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Implementacion
{
    public class UbicacionService : IUbicacionService
    {
        private readonly IRepository<Ubicacion> _repository;
        private readonly IMapper _mapper;
        private const int _usuarioId = 1; //TODO: Modificar por el código del usuario autenticado

        public UbicacionService(IRepository<Ubicacion> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Save(UbicacionDto dto)
        {
            Ubicacion ubicacion;

            if (dto.Id == 0)
            {
                ubicacion = _mapper.Map<Ubicacion>(dto);
                BaseEntityHelper.SetCreated(ubicacion, _usuarioId);
                await _repository.Add(ubicacion);
            }
            else
            {
                ubicacion = await _repository.Get(dto.Id);
                if (ubicacion == null)
                {
                    throw new KeyNotFoundException("La ubicación no existe.");
                }

                _mapper.Map(dto, ubicacion);
                BaseEntityHelper.SetUpdated(ubicacion, _usuarioId);
                await _repository.Update(ubicacion);
            }

            return ubicacion.Id;
        }

        public async Task<UbicacionDto> GetById(int id)
        {
            var ubicacion = await _repository.Get(id);
            if (ubicacion == null)
            {
                throw new KeyNotFoundException("La ubicación no existe.");
            }

            return _mapper.Map<UbicacionDto>(ubicacion);
        }

        public async Task<IEnumerable<UbicacionDto>> GetAll()
        {
            var ubicaciones = await _repository.GetAll();
            return ubicaciones.Select(u => _mapper.Map<UbicacionDto>(u));
        }

        public async Task<bool> Delete(int id)
        {
            var ubicacion = await _repository.Get(id);
            if (ubicacion == null)
            {
                throw new KeyNotFoundException("La ubicación no existe.");
            }

            await _repository.Delete(ubicacion);
            return true;
        }
    }
}
