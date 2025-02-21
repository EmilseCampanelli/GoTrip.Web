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
        private readonly IPlanViajeRepository _planViajeRepository;
        private readonly IMapper _mapper;
        private const int _usuarioId = 1; //TODO: Modificar por el codigo del usuario autenticado

        public PlanViajeService(IRepository<PlanViaje> repository, IMapper mapper, IRepository<LineaPlanViaje> lineaPuntoRepository, IPlanViajeRepository planViajeRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _lineaPuntoRepository = lineaPuntoRepository;
            _planViajeRepository = planViajeRepository;
        }
        public async Task Activate(int id)
        {
            var planViaje = await _repository.Get(id);
            BaseEntityHelper.SetActive(planViaje, _usuarioId);
            _repository.Update(planViaje);
        }

        public async Task<bool> Exists(int id)
        {
            return await _repository.Get(id) != null;
        }

        public async Task<PlanViajeDto> Get(int id)
        {
            var model = await _repository.Get(id);
            var mapeo = _mapper.Map<PlanViajeDto>(model);
            mapeo.LineaPlanViaje = _mapper.Map<List<LineaPlanViajeDto>>(model.LineaPlanViaje);
            return mapeo;
        }

        public async Task Inactivate(int id)
        {
            var planViaje = await _repository.Get(id);
            BaseEntityHelper.SetInactive(planViaje, _usuarioId);
            _repository.Update(planViaje);
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
                if (dto.LineaPlanViaje.Count < 1)
                {
                    throw new Exception("Debe ingresar al menos un punto turistico");
                }
                var newPlan = new PlanViaje();
                newPlan.Descripcion = dto.Descripcion;
                newPlan.FechaFin = dto.FechaFin;
                newPlan.FechaInicio = dto.FechaInicio;
                BaseEntityHelper.SetCreated(newPlan, dto.UsuarioId);
                planViajeEntity = await _repository.Add(newPlan);
                AddItem(dto.LineaPlanViaje, planViajeEntity.Id);

            }
            else
            {
                var updatePlan = new PlanViaje();
                updatePlan.Descripcion = dto.Descripcion;
                updatePlan.FechaFin = dto.FechaFin;
                updatePlan.FechaInicio = dto.FechaInicio;
                updatePlan.Id = dto.Id;
                BaseEntityHelper.SetUpdated(updatePlan, dto.UsuarioId);
                planViajeEntity = _repository.Update(updatePlan);

                DeleteItem(dto.Id);
                AddItem(dto.LineaPlanViaje, dto.Id);
            }

            return _mapper.Map<PlanViajeDto>(_repository.Get(planViajeEntity.Id).Result);
        }

        public async Task<(bool isValid, string message)> Validate(int? id, PlanViajeDto dto)
        {
            var validations = new List<(bool isValid, string message)>();
            var Valid = true;
            var messageTest = "is true";
            validations.Add((Valid, messageTest));
            return (isValid: validations.All(x => x.isValid),
                    message: string.Join(Environment.NewLine, validations.Where(x => !x.isValid).Select(x => x.message)));
        }

        public async Task<List<PlanViajeDto>> GetAll()
        {
            var planes = await _repository.GetAll();
            return _mapper.Map<List<PlanViajeDto>>(planes);
        }

        public List<PlanViajeDto> GetByDates(DateTime startDate, DateTime endDate, UsuarioDto usuario)
        {
            throw new NotImplementedException();
        }

        public  void AddItem(List<LineaPlanViajeDto> lineas, int idPlanViaje)
        {
            var newLineaPlanes = new List<LineaPlanViaje>();

            for (int i = 0; i < lineas.Count; i++)
            {
                var newLineaPlan = new LineaPlanViaje
                {
                    PlanViajeId = idPlanViaje,
                    PuntoTuristicoId = lineas[i].PuntoTuristicoId,
                    EventoId = lineas[i].EventoId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    State = Dominio.Enums.BaseState.Activo,
                    UsuarioId = _usuarioId
                };

                newLineaPlanes.Add(newLineaPlan);
            }

             _lineaPuntoRepository.AddRangeAsync(newLineaPlanes);
        }

        public void DeleteItem(int idPlanViaje)
        {
            var lineas = _planViajeRepository.GetLineaPlanViaje(idPlanViaje);

            if (lineas == null || !lineas.Any())
                return;
            _lineaPuntoRepository.DeleteRange(lineas);

        }

        public  List<PlanViajeDto> GetActives(int userId)
        {
            var planes = _planViajeRepository.GetAllActivesByUser(userId);
            return _mapper.Map<List<PlanViajeDto>>(planes);
        }

        public List<PlanViajeDto> GetAllByUser(int userId)
        {
            var planes = _planViajeRepository.GetAllByUser(userId);
            return _mapper.Map<List<PlanViajeDto>>(planes);
        }
    }
}
