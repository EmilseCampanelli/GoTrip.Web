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
        void AddItem(List<LineaPlanViajeDto> lineas, int idPlanViaje);
        void DeleteItem(int idPlanViaje);
        List<PlanViajeDto> GetActives(int userId);
        List<PlanViajeDto> GetAllByUser(int userId);
    }
}
