using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Dominio.Entidades
{
    public class LineaPuntoTuristico : BaseEntity
    {
        public virtual PlanViaje PlanViaje { get; set; }
        public virtual PuntoTuristico? PuntoTuristico { get; set; }
        public virtual Evento? evento { get; set; }

    }
}
