using GoTrip.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoTrip.Dominio.Contratos
{
    public interface ILineaPuntoTuristicoRepository : IRepository<LineaPuntoTuristico>
    {
        Task SaveAll(List<LineaPuntoTuristico> list);
        Task UpdateAll(List<LineaPuntoTuristico> list);
    }
}
