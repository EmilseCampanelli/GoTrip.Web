using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class LineaPlanViajeDto : BaseEntityDto
    {
        public int IdPlanViaje { get; set; }
        public int? PuntoTuristicoId { get; set; }
        public int? EventoId { get; set; }
        public PuntoTuristicoDto? PuntoTuristico { get; set; }
        public EventoDto? Evento { get; set; }
        //public virtual PlanViajeDto? PlanViaje { get; set; }
        public bool IsEvent
        {
            get => EventoId != null || EventoId ==0;
        }
    }
}
