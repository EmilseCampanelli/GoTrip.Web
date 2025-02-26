using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Dominio.Contratos
{
    public interface IReporteRepository
    {
        List<PuntoTuristicoMasVisitado> GetPuntoTuristicoMasVisitado();
        List<PlanesPorMes> CantidadPlanesViajesRealizados();
        int CantidadUsuariosNoVidentesActivos();
        int CantidadUsuariosVidentesActivos();
    }
}
