using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Dominio.Contratos
{
    public interface IPlanViajeRepository 
    {
        PlanViaje GetPlanViaje(int id);
        List<LineaPlanViaje> GetLineaPlanViaje(int idPlanViaje);
        List<PlanViaje> GetAllByUser(int userId);
        List<PlanViaje> GetAllActivesByUser(int userId);
    }
}
