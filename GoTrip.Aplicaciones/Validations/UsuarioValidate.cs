using FluentValidation;
using GoTrip.Aplicaciones.Dtos;

namespace GoTrip.Aplicaciones.Validations
{
    public class UsuarioValidate : AbstractValidator<UsuarioDto>
    {
        public UsuarioValidate()
        {
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Password).NotEmpty();
            RuleFor(c => c.UserName).NotEmpty();
        }
    }
}
