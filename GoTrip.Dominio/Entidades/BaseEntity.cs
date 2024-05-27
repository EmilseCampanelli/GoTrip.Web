using GoTrip.Dominio.Enums;

namespace GoTrip.Dominio.Entidades
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public BaseState State { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
