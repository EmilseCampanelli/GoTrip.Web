using GoTrip.Aplicaciones.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Interfaces
{
    public interface IEventoService : IGenericService<EventoDto>
    {
        Task<string> PutImage(List<IFormFile> images, int id);
    }
}
