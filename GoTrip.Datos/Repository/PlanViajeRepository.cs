using GoTrip.Datos.Context;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
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

        public List<LineaPlanViaje> GetLineaPlanViaje(int idPlanViaje)
        {
            return _context.LineaPuntoTuristicos.Where(l => l.PlanViajeId == idPlanViaje).ToList();
        }

        public List<PlanViaje> GetAllByUser(int userId)
        {
            return  _context.PlanViajes.Where(e => e.UsuarioId == userId).ToList();
        }

        public List<PlanViaje> GetAllActivesByUser(int userId)
        {
            return _context.PlanViajes.Where(e => e.UsuarioId == userId && e.State == Dominio.Enums.BaseState.Activo).ToList();
        }
    }
}
