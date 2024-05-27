using GoTrip.Dominio.Enums;

namespace GoTrip.Dominio.Entidades
{
    public class Rol : BaseEntity
    {
        public TipoRol Tipo { get; set; }

        public virtual List<Permiso> Permisos { get; set; }
    }
}
