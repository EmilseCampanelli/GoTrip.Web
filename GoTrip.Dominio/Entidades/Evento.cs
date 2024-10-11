namespace GoTrip.Dominio.Entidades
{
    public class Evento : BaseEntity
    {
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int UbicacionId { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Ubicacion Ubicacion { get; set; }
        public string PathImagen { get; set; }
        public virtual List<Comentario> Comentarios { get; set; }
    }
}
