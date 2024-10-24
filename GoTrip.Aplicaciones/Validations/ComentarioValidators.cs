using FluentValidation;
using GoTrip.Aplicaciones.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Validations
{
    public class ComentarioValidators : AbstractValidator<ComentarioDto>
    {
        public ComentarioValidators()
        {
            RuleFor(c => c.CantidadEstrellas < 6 && c.CantidadEstrellas >0).NotNull().NotEmpty();
        }
    }
}
