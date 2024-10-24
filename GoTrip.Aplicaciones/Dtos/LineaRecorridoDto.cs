using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class LineaRecorridoDto : BaseEntityDto
    {
        public int RecorridoId { get; set; }
        public PuntoTuristicoDto? PuntoTuristicoDto { get; set; }
        public EventoDto? EventoDto { get; set; }

    }
}
