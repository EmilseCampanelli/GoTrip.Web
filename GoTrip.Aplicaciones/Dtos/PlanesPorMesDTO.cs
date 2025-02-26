using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class PlanesPorMesDTO
    {
        public int Mes { get; set; }
        public string MesNombre {get => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Mes); }
        public int Anio { get; set; }
        public int CantidadPlanes { get; set; }
        public string Detalle { get => $"{MesNombre} {Anio} - Cantidad de Planes de Viajes realizados: {CantidadPlanes}"; }
    }
}
