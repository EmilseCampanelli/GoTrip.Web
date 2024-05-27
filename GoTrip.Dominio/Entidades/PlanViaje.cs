using GoTrip.Dominio.Enums;

namespace GoTrip.Dominio.Entidades
{
    public class PlanViaje : BaseEntity
    {
        public string Descriocion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public EstadoPlanViaje Estado { get; set; }
    }
}
