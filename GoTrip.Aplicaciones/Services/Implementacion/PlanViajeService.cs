using AutoMapper;
using GoTrip.Aplicaciones.Dtos;
using GoTrip.Aplicaciones.Helper;
using GoTrip.Aplicaciones.Services.Interfaces;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Implementacion
{
    public class PlanViajeService : IPlanViajeService
    {
        private readonly IRepository<PlanViaje> _repository;
        private readonly ILineaPuntoTuristicoRepository _lineaPuntoRepository;
        private readonly ILineaRecorridoRepository _lineaRecorridoRepository;
        private readonly IMapper _mapper;
        private const int _usuarioId = 1; //TODO: Modificar por el codigo del usuario autenticado

        public PlanViajeService(IRepository<PlanViaje> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task Activate(int id)
        {
            var planViaje = await _repository.Get(id);
            BaseEntityHelper.SetActive(planViaje, _usuarioId);
            await _repository.Update(planViaje);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repository.Get(id) != null;
        }

        public async Task<PlanViaje> Get(int id)//falta modificar para traer dtos correctos.
        {
            var model = await _repository.Get(id);
            return _mapper.Map<PlanViaje>(model);
        }

        public async Task Inactivate(int id)
        {
            var planViaje = await _repository.Get(id);
            BaseEntityHelper.SetActive(planViaje, _usuarioId);
            await _repository.Update(planViaje);
        }

        public async Task<PlanViaje> Save(PlanViaje dto)
        {
            PlanViaje planViaje = new PlanViaje();
            if (dto.Id.Equals(0))
            {
                planViaje = _mapper.Map<PlanViaje>(dto);
                foreach(var linea in dto.LineaPuntos)
                {
                    LineaPuntoTuristico lineaPtoTur = new LineaPuntoTuristico();
                    lineaPtoTur = _mapper.Map<LineaPuntoTuristico>(linea);
                    planViaje.LineaPuntos.Add(lineaPtoTur);
                }
                foreach(var linea in dto.LineaRecorridos)
                {
                    LineaRecorrido lineaRecorrido = new LineaRecorrido();
                    lineaRecorrido = _mapper.Map<LineaRecorrido>(linea);
                    planViaje.LineaRecorridos.Add(lineaRecorrido);
                }
                BaseEntityHelper.SetCreated(planViaje, dto.UsuarioId);
                await _lineaPuntoRepository.SaveAll(planViaje.LineaPuntos);
                await _lineaRecorridoRepository.SaveAll(planViaje.LineaRecorridos);
                await _repository.Add(planViaje);
            }
            else
            {
                var updatedComentario = _mapper.Map<Comentario>(dto);
                BaseEntityHelper.SetUpdated(updatedComentario, _usuarioId);
                await _repository.Update(updatedComentario);
            }
            return _mapper.Map<ComentarioDto>(dto);
        }

        public Task<PlanViajeDto> Save(PlanViajeDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<(bool isValid, string message)> Validate(int? id, PlanViaje dto)
        {
            throw new NotImplementedException();
        }

        public Task<(bool isValid, string message)> Validate(int? id, PlanViajeDto dto)
        {
            throw new NotImplementedException();
        }

        Task<PlanViajeDto> IGenericService<PlanViajeDto>.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
