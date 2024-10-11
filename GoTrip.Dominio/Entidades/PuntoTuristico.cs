namespace GoTrip.Dominio.Entidades
{
    public class PuntoTuristico : BaseEntity
    {
        public string Descripcion { get; set; }

        public int? UbicacionId { get; set; }

        public virtual Ubicacion Ubicacion { get; set; }

        public int? CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual List<Recorrido> Recorridos { get; set; }
        public string PathImagen { get; set; }

    }
}
