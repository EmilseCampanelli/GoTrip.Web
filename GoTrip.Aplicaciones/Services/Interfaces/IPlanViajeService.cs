using GoTrip.Aplicaciones.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Interfaces
{
    public interface IPlanViajeService : IGenericService<PlanViajeDto>
    {
        List<PlanViajeDto> GetByDates(DateTime startDate, DateTime endDate, UsuarioDto usuario);
        List<RecorridoDto> GetRecorridosByPlanViaje(int idPlanViaje);
        Task<PlanViajeDto> AddItem(List<LineaPlanViajeDto> lineas, int idPlanViaje);
        PlanViajeDto AddRecorridos(List<RecorridoDto> recorrido, int idPlanViaje);
        PlanViajeDto DeleteItem(int idPlanViaje, LineaPlanViajeDto lineaPlanViajeDto);
    }
}
