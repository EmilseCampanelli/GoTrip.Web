using GoTrip.Aplicaciones.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoTrip.Aplicaciones.Services.Interfaces
{
    public interface IUbicacionService
    {
        /// <summary>
        /// Guarda o actualiza una ubicación.
        /// </summary>
        /// <param name="ubicacion">Datos de la ubicación</param>
        /// <returns>ID de la ubicación creada o actualizada</returns>
        Task<int> Save(UbicacionDto ubicacion);

        /// <summary>
        /// Obtiene una ubicación por su ID.
        /// </summary>
        /// <param name="id">ID de la ubicación</param>
        /// <returns>Datos de la ubicación</returns>
        Task<UbicacionDto> GetById(int id);

        /// <summary>
        /// Obtiene todas las ubicaciones.
        /// </summary>
        /// <returns>Lista de ubicaciones</returns>
        Task<IEnumerable<UbicacionDto>> GetAll();

        /// <summary>
        /// Elimina una ubicación por su ID.
        /// </summary>
        /// <param name="id">ID de la ubicación a eliminar</param>
        /// <returns>True si se eliminó exitosamente, False en caso contrario</returns>
        Task<bool> Delete(int id);
    }
}
