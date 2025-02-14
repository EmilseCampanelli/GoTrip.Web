using GoTrip.Aplicaciones.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Interfaces
{
    public interface IAutenticacionService
    {
        Task<AutenticacionResponse> Login(string username, string password);
    }
}
