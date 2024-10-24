namespace GoTrip.Dominio.Entidades
{
    public class Categoria : BaseEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string State { get; set; }
        public int UsuarioId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual List<Caracteristica> Caracteristicas { get; set; }
    }
}
