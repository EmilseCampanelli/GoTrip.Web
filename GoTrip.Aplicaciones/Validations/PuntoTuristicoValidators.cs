using FluentValidation;
using GoTrip.Aplicaciones.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Validations
{
    public class PuntoTuristicoValidators : AbstractValidator<PuntoTuristicoDto>
    {
        public PuntoTuristicoValidators()
        {
            RuleFor(c => c.Descripcion).NotNull().NotEmpty();
        }
    }
}
