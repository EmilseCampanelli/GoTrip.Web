using GoTrip.Dominio.Enums;

namespace GoTrip.Dominio.Entidades
{
    public class PlanViaje : BaseEntity
    {
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public virtual List<LineaPuntoTuristico> LineaPuntos { get; set; }
        public virtual List<LineaRecorrido>? LineaRecorridos { get; set; }
        public EstadoPlanViaje Estado { get; set; }
    }
}
