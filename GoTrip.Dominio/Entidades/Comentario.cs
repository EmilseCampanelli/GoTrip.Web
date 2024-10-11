using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Dominio.Entidades
{
    public class Comentario : BaseEntity
    {
        public string Texto {  get; set; }
        public int CantidadEstrellas { get; set; }
        public int? PuntoTuristicoId { get; set; }
        public int? EventoId { get; set; }
        public virtual PuntoTuristico? PuntoTuristico { get; set; }
        public virtual Evento? Evento { get; set; }
    }
}
