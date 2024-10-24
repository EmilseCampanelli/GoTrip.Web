using FluentValidation;
using GoTrip.Aplicaciones.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Validations
{
    public class CategoriaValidators : AbstractValidator<CategoriaDto>
    {
        public CategoriaValidators()
        {
            RuleFor(c => c.Descripcion).NotNull().NotEmpty();
        }
    }
}
