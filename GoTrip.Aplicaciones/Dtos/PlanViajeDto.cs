using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class PlanViajeDto : BaseEntityDto
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }
        public List<int> EventosId { get; set; }
        public List<int> PuntosId { get; set; }
        public List<int>? RecorridosId { get; set; }
        public string EstadoPlan { get; set; }
    }
}
