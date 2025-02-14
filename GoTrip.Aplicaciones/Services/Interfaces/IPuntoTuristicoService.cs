using GoTrip.Aplicaciones.Dtos;
using Microsoft.AspNetCore.Http;

namespace GoTrip.Aplicaciones.Services.Interfaces
{
    public interface IPuntoTuristicoService : IGenericService<PuntoTuristicoDto>
    {
        Task<string> PutImage(List<IFormFile> images, int id);
        
    }
}
