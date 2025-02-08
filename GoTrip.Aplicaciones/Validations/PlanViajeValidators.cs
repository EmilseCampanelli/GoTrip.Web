using FluentValidation;
using GoTrip.Aplicaciones.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Validations
{
    public class PlanViajeValidators : AbstractValidator<PlanViajeDto>
    {
        public PlanViajeValidators() 
        {
            RuleFor(c => c.FechaInicio <= c.FechaFin).NotNull().NotEmpty();
        }
    }
}
