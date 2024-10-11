using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Dtos
{
    public class ComentarioDto : BaseEntityDto
    {
        public string Texto {  get; set; }
        public int CantidadEstrellas { get; set; }
        public int? PuntoTuristicoId { get; set; }
        public int? EventoId { get; set; }
        public virtual PuntoTuristicoDto? PuntoTuristico { get; set; }
        public virtual EventoDto? Evento { get; set; }
    }
}
