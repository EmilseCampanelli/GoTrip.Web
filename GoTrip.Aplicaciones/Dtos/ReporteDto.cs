using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class ReporteDto
    {
        public List<PuntoTuristicoMasVisitadoDTO> PuntosMasVisitados { get; set; }
        public List<PlanesPorMesDTO> CantPlanesDeViaje { get; set; }
        public int CantUsuariosVidentesActivos { get; set; }
        public int CantUsuariosNoVidentesActivos { get; set; }

    }
}
