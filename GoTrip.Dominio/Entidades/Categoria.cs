namespace GoTrip.Dominio.Entidades
{
    public class Categoria : BaseEntity
    {
        public string Descripcion { get; set; }

        public virtual List<Caracteristica> Caracteristicas { get; set; }
    }
}
