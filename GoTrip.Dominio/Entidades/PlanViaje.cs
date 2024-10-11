using GoTrip.Dominio.Enums;

namespace GoTrip.Dominio.Entidades
{
    public class PlanViaje : BaseEntity
    {
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public virtual List<Evento> Eventos { get; set; }
        public virtual List<PuntoTuristico> Puntos { get; set; }
        public virtual List<Recorrido> Recorridos { get; set; }
        public EstadoPlanViaje Estado { get; set; }
    }
}
