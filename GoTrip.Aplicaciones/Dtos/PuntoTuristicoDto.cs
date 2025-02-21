namespace GoTrip.Aplicaciones.Dtos
{
    public class PuntoTuristicoDto : BaseEntityDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaDto? Categoria { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string? PathImagen { get; set; }
        //public List<ComentarioDto>? Comentarios { get; set; }
    }
}
