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
        private readonly IRepository<LineaPlanViaje> _lineaPuntoRepository;
         private readonly IMapper _mapper;
        private const int _usuarioId = 1; //TODO: Modificar por el codigo del usuario autenticado

        public PlanViajeService(IRepository<PlanViaje> repository, IMapper mapper, IRepository<LineaPlanViaje> lineaPuntoRepository)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._lineaPuntoRepository = lineaPuntoRepository;
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
            var model = await _repository.Get(id);
            var mapeo = _mapper.Map<PlanViajeDto>(model);
            mapeo.LineaPlanViaje = _mapper.Map<List<LineaPlanViajeDto>>(model.LineaPuntos);
            return mapeo;
        }

        public async Task Inactivate(int id)
        {
            var planViaje = await _repository.Get(id);
            BaseEntityHelper.SetActive(planViaje, _usuarioId);
            await _repository.Update(planViaje);
        }

        public async Task<PlanViajeDto> Save(PlanViajeDto dto)
        {
            PlanViaje planViajeEntity = new PlanViaje();

            if (dto.FechaInicio == null)
            {
                throw new Exception("El plan de viaje no se puede crear sin una fecha de inicio");
            }

            if (dto.Id.Equals(0))
            {
                if(dto.LineaPlanViaje.Count < 1)
                {
                    throw new Exception("Debe ingresar al menos un punto turistico");
                }
                var newPlan = new PlanViaje();
                newPlan.Descripcion = dto.Descripcion;
                newPlan.Estado = dto.Estado;
                newPlan.FechaFin = dto.FechaFin;
                newPlan.FechaInicio = dto.FechaInicio;
                BaseEntityHelper.SetCreated(newPlan, _usuarioId);
                planViajeEntity = await _repository.Add(newPlan);
                var plan =  AddItem(dto.LineaPlanViaje, planViajeEntity.Id).Result;

            }
            else
            {
                var updatePlan = new PlanViaje();
                updatePlan.Descripcion = dto.Descripcion;
                updatePlan.Estado = dto.Estado;
                updatePlan.FechaFin = dto.FechaFin;
                updatePlan.FechaInicio  = dto.FechaInicio;
                updatePlan.Id = dto.Id;
                BaseEntityHelper.SetUpdated(updatePlan, _usuarioId);
                planViajeEntity = await _repository.Update(updatePlan);
            }

            return _mapper.Map<PlanViajeDto>(planViajeEntity);
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

        public List<PlanViajeDto> GetByDates(DateTime startDate, DateTime endDate, UsuarioDto usuario)
        {
            throw new NotImplementedException();
        }

        public List<RecorridoDto> GetRecorridosByPlanViaje(int idPlanViaje)
        {
            throw new NotImplementedException();
        }

        public PlanViajeDto AddRecorridos(List<RecorridoDto> recorrido)
        {
            throw new NotImplementedException();
        }

        public async Task<PlanViajeDto> AddItem(List<LineaPlanViajeDto> lineas, int idPlanViaje)
        {
            for(int i=0; i < lineas.Count; i++)
            {
                var newLineaPlan = new LineaPlanViaje();
                newLineaPlan.PlanViajeId = idPlanViaje;
                newLineaPlan.PuntoTuristicoId = lineas[i].PuntoTuristicoId;
                newLineaPlan.EventoId = lineas[i].EventoId;
                newLineaPlan.CreatedDate = DateTime.Now;
                newLineaPlan.UpdatedDate = DateTime.Now;
                newLineaPlan.State = Dominio.Enums.BaseState.Activo;
                newLineaPlan.UsuarioId = _usuarioId;

                _lineaPuntoRepository.Add(newLineaPlan);
            }

            return _mapper.Map<PlanViajeDto>(_repository.Get(idPlanViaje).Result);
        }

        public PlanViajeDto AddRecorridos(List<RecorridoDto> recorrido, int idPlanViaje)
        {
            throw new NotImplementedException();
        }

        public PlanViajeDto DeleteItem(int idPlanViaje, LineaPlanViajeDto lineaPlanViajeDto)
        {
            throw new NotImplementedException();
        }
    }
}
