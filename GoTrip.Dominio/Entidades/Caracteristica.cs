namespace GoTrip.Dominio.Entidades
{
    public class Caracteristica : BaseEntity
    {
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
