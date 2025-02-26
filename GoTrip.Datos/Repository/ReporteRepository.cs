using GoTrip.Datos.Context;
using GoTrip.Dominio.Contratos;
using GoTrip.Dominio.Entidades;
using GoTrip.Dominio.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Datos.Repository
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly GoTripContext _context;

        public ReporteRepository(GoTripContext context)
        {
            _context = context;
        }

        public List<PlanesPorMes> CantidadPlanesViajesRealizados()
        {
            var planesPorMes = _context.PlanViajes
                .GroupBy(p => new { Mes = p.FechaInicio.Month, Anio = p.FechaInicio.Year })
                .Select(g => new PlanesPorMes
                {
                    Mes = g.Key.Mes,
                    Anio = g.Key.Anio,
                    CantidadPlanes = g.Count()
                })
                .OrderByDescending(x => x.Anio)
                .ThenByDescending(x => x.Mes)
                .ToList();

            return planesPorMes;
        }

        public int CantidadUsuariosNoVidentesActivos()
        {
            var users = _context.Usuarios.Where(u => (u.IsNoVidente != null && u.IsNoVidente.Value) && u.State == BaseState.Activo).ToList();

            return users.Count;
        }

        public int CantidadUsuariosVidentesActivos()
        {
            var users = _context.Usuarios.Where(u => (u.IsNoVidente == null || !u.IsNoVidente.Value) && u.State == BaseState.Activo).ToList();

            return users.Count;
        }

        public List<PuntoTuristicoMasVisitado> GetPuntoTuristicoMasVisitado()
        {
            DateTime fechaLimite = DateTime.Now.AddMonths(-3);

            var topPuntosTuristicos = _context.LineaPuntoTuristicos
                 .Join(_context.PlanViajes,
                     linea => linea.PlanViajeId,
                     plan => plan.Id,
                     (linea, plan) => new { linea.PuntoTuristico, plan.FechaInicio })
                 .Where(x => x.FechaInicio >= fechaLimite) // Filtrar últimos 3 meses
                 .GroupBy(x => x.PuntoTuristico)
                 .Select(g => new PuntoTuristicoMasVisitado
                 {
                     PuntoTuristico = g.Key.Nombre,
                     CantidadVisitas = g.Count()
                 })
                 .OrderByDescending(x => x.CantidadVisitas)
                 .Take(10) // Top 10
                 .ToList();

            return topPuntosTuristicos;
        }
    }
}
