using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Dominio.Entidades
{
    public class LineaRecorrido : BaseEntity
    {
        public int? EventoId { get; set; }
        public int? PuntoTuristicoId { get; set; }
        public int RecorridoId { get; set; }
        public int PlanViajeId { get; set; }
        public Evento? Evento { get; set; }
        public PuntoTuristico? PuntoTuristico { get; set; }
        public PlanViaje PlanViaje { get; set; }
    }
}
