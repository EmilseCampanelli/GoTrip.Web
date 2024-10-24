using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Dominio.Entidades
{
    public class LineaRecorrido : BaseEntity
    {
        public Evento? Evento { get; set; }
        public PuntoTuristico? PuntoTuristico { get; set; }
        public Recorrido Recorrido { get; set; }
    }
}
