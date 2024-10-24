using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class LineaPuntoTuristicoDto : BaseEntityDto
    {
        public int IdPlanViaje { get; set; }
        public PuntoTuristicoDto? Punto { get; set; }
        public EventoDto? Evento { get; set; }

    }
}
