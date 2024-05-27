namespace GoTrip.Dominio.Entidades
{
    public class Permiso : BaseEntity 
    {
        public string Descripcion { get; set; }
        public virtual List<Rol> Roles { get; set; }
    }
}
