namespace GoTrip.Dominio.Entidades
{
    public class Recorrido : BaseEntity
    {
        public int PlanViajeId { get; set; }
        public virtual PlanViaje PlanViaje { get; set; }
        public virtual List<LineaRecorrido> LineaRecorridos { get; set; }
    }
}
