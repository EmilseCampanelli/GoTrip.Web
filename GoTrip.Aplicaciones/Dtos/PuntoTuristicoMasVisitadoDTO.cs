using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class PuntoTuristicoMasVisitadoDTO
    {
        public string PuntoTuristico { get; set; }
        public int CantidadVisitas { get; set; }
        public string Detalle { get => $"{PuntoTuristico}: {CantidadVisitas} visitas"; }
    }
}
