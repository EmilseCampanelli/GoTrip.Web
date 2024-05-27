namespace GoTrip.Dominio.Entidades
{
    public class Evento : BaseEntity
    {
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int UbicacionId { get; set; }

        public virtual Ubicacion Ubicacion { get; set; }
        public virtual List<Recorrido> Recorridos { get; set; }
    }
}
