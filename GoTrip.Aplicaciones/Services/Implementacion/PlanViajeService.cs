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

        public async Task<PlanViajeDto> Get(int id)
        {
            //var model = await _repository.Get(id);
            //return _mapper.Map<PlanViaje>(model);

            // Obtener el modelo de PlanViaje
            var model = await _repository.Get(id);

            // Mapear el modelo a PlanViajeDto
            var mapeo = _mapper.Map<PlanViajeDto>(model);

            // Obtener las líneas de puntos turísticos asociadas al PlanViaje
            var lineaPuntosT = await _lineaPuntoRepository.GetLineasConPlanViajeId(id);

            // Mapear las líneas de puntos turísticos a DTOs y añadirlas al DTO del PlanViaje
            mapeo.PuntosId = _mapper.Map<List<LineaPuntoTuristicoDto>>(lineaPuntosT);

            // Si necesitas agregar las líneas de recorrido (suponiendo que también están en el DTO)
            var lineaRecorridos = await _lineaRecorridoRepository.GetLineasConPlanViajeId(id);
            mapeo.RecorridosId = _mapper.Map<List<LineaRecorridoDto>>(lineaRecorridos);

            // Retornar el DTO completo
            return mapeo;
        }

        public async Task Inactivate(int id)
        {
            var planViaje = await _repository.Get(id);
            BaseEntityHelper.SetActive(planViaje, _usuarioId);
            await _repository.Update(planViaje);
        }

        public async Task<PlanViajeDto> Save(PlanViaje dto)
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
                planViaje = _mapper.Map<PlanViaje>(dto);
                foreach (var linea in dto.LineaPuntos)
                {
                    LineaPuntoTuristico lineaPtoTur = new LineaPuntoTuristico();
                    lineaPtoTur = _mapper.Map<LineaPuntoTuristico>(linea);
                    planViaje.LineaPuntos.Add(lineaPtoTur);
                }
                foreach (var linea in dto.LineaRecorridos)
                {
                    LineaRecorrido lineaRecorrido = new LineaRecorrido();
                    lineaRecorrido = _mapper.Map<LineaRecorrido>(linea);
                    planViaje.LineaRecorridos.Add(lineaRecorrido);
                }
                BaseEntityHelper.SetUpdated(planViaje, dto.UsuarioId);
                await _lineaPuntoRepository.UpdateAll(planViaje.LineaPuntos);
                await _lineaRecorridoRepository.UpdateAll(planViaje.LineaRecorridos);
                await _repository.Update(planViaje);
            }
            return _mapper.Map<PlanViajeDto>(planViaje);
        }

        public Task<PlanViajeDto> Save(PlanViajeDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool isValid, string message)> Validate(int? id, PlanViajeDto dto)
        {
            var validations = new List<(bool isValid, string message)>();
            var Valid = true;
            var messageTest = "is true";
            validations.Add((Valid,messageTest));
            return (isValid: validations.All(x => x.isValid),
                    message: string.Join(Environment.NewLine, validations.Where(x => !x.isValid).Select(x => x.message)));
        }

        public Task<List<PlanViajeDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
