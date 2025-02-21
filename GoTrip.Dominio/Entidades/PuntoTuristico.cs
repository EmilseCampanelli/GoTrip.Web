namespace GoTrip.Dominio.Entidades
{
    public class PuntoTuristico : BaseEntity
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Latitud { get; set; }

        public string Longitud { get; set; }

        public int? CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        public string? PathImagen { get; set; }

        //public virtual List<Comentario> Comentarios { get; set; }

    }
}
