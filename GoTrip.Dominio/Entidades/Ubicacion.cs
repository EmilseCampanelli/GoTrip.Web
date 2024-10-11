namespace GoTrip.Dominio.Entidades
{
    public class Ubicacion : BaseEntity
    {
        public string Descripcion { get; set; } //calle
        public string Longitud  { get; set; }
        public string Latitud { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Pais {  get; set; }

    }
}
