namespace GoTrip.Dominio.Entidades
{
    public class Ubicacion : BaseEntity
    {
        public string Descripcion { get; set; }
        public string Longitud  { get; set; }
        public string Latitud { get; set; }

        public int LocalidadId { get; set; }
        public virtual Localidad Localidad { get; set; }

    }
}
