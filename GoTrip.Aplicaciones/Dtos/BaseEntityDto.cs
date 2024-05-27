using GoTrip.Dominio.Enums;

namespace GoTrip.Aplicaciones.Dtos
{
    public class BaseEntityDto : BaseDto
    {
        public DateTime? UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public BaseState State { get; set; }
        public int UsuarioId { get; set; }
    }
}
