using GoTrip.Datos.Context;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Datos.Repository
{
    public class PlanViajeRepository : IPlanViajeRepository
    {
        private readonly GoTripContext _context;

        public PlanViajeRepository(GoTripContext context)
        {
            _context = context;
        }

        public PlanViaje GetPlanViaje(int id)
        {
            throw new NotImplementedException();
        }
    }
}
