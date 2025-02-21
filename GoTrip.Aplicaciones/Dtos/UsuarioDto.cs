using GoTrip.Dominio.Enums;
using System.Text.Json.Serialization;

namespace GoTrip.Aplicaciones.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public double Documento { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public BaseState State { get; set; }
        public bool? IsNoVidente { get; set; }
        public bool IsAdmin { get; set; }
    }
}
