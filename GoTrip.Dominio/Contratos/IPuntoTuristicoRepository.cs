using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Dominio.Contratos
{
    public interface IPuntoTuristicoRepository : IRepository<PuntoTuristico>
    {
        Task<PuntoTuristico> GetPunto(int id);
        Task<IEnumerable<PuntoTuristico>> GetPuntosTuristicos();
    }
}
